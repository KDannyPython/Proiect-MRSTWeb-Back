using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Models.Calendar;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Workout;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.BusinessLayer.Structure;

public class CalendarAction
{
    protected readonly AppDbContext _context;
    public CalendarAction()
    {
        _context = new AppDbContext();
    }

    public async Task<Dictionary<string, CalendarDayDto>> GetMonthAction(int userId, int year, int month)
    {
        var startDate = DateTime.SpecifyKind(
            new DateTime(year, month, 1),
            DateTimeKind.Utc);
        var endDate = startDate.AddMonths(1);

        var foodLogs = await _context.FoodLogs
            .Include(f => f.Food)
            .Where(f =>
                f.UserId == userId &&
                f.LoggedAt >= startDate &&
                f.LoggedAt < endDate)
            .ToListAsync();

        var waterLogs = await _context.WaterLogs
            .Where(w =>
                w.UserId == userId &&
                w.LoggedAt >= startDate &&
                w.LoggedAt < endDate)
            .ToListAsync();

        var workouts = await _context.Workouts
            .Where(w =>
                w.UserId == userId &&
                w.Date >= startDate &&
                w.Date < endDate)
            .ToListAsync();

        var result = new Dictionary<string, CalendarDayDto>();

        for (var date = startDate; date < endDate; date = date.AddDays(1))
        {
            var dateKey = date.ToString("yyyy-MM-dd");

            var calories = foodLogs
                .Where(f => f.LoggedAt.Date == date.Date)
                .Sum(f => (f.Food.Calories * f.QuantityGrams) / 100);

            var waterMl = waterLogs
                .Where(w => w.LoggedAt.Date == date.Date)
                .Sum(w => w.AmountMl);

            var workoutsCount = workouts
                .Count(w => w.Date.Date == date.Date);

            result[dateKey] = new CalendarDayDto
            {
                Calories = (int)calories,
                WaterMl = waterMl,
                WorkoutsCount = workoutsCount
            };
        }

        return result;
    }

    public async Task<CalendarDayDetailsDto> GetDayAction(int userId, DateTime date)
    {
        date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
        var foodLogs = await _context.FoodLogs
            .Include(f => f.Food)
            .Where(f =>
                f.UserId == userId &&
                f.LoggedAt.Date == date.Date)
            .ToListAsync();

        var waterLogs = await _context.WaterLogs
            .Where(w =>
                w.UserId == userId &&
                w.LoggedAt.Date == date.Date)
            .ToListAsync();

        var workouts = await _context.Workouts
            .Where(w =>
                w.UserId == userId &&
                w.Date.Date == date.Date)
            .ToListAsync();

        return new CalendarDayDetailsDto
        {
            Calories = (int)foodLogs.Sum(f =>
                (f.Food.Calories * f.QuantityGrams) / 100),

            CalGoal = 2200,

            WaterMl = waterLogs.Sum(w => w.AmountMl),

            WaterGoal = 3000,

            Workouts = workouts.Select(w => new WorkoutInfoDto
            {
                Id = w.Id,
                UserId = w.UserId,
                Date = w.Date,
                Duration = w.Duration,
                Type = w.Type,
                Label = w.Label
            }).ToList()
        };
    }
}
