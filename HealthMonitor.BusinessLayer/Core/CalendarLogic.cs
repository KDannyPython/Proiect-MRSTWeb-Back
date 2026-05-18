using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Calendar;
using HealthMonitor.Domain.Models.Food;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Core;

public class CalendarLogic : CalendarAction, ICalendarLogic
{

    public async Task<Dictionary<string, CalendarDayDto>> GetMonth(int userId, int year, int month)
    {
        var result = await GetMonthAction(userId, year, month);

        return result;
    }

    public async Task<CalendarDayDetailsDto> GetDay(int userId, DateTime date)
    {
        var result = await GetDayAction(userId, date);

        return result;
    }
}
