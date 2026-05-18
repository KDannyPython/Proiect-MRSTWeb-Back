using HealthMonitor.Domain.Models.Calendar;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface ICalendarLogic
    {
        Task<Dictionary<string, CalendarDayDto>> GetMonth(int userId, int year, int month);

        Task<CalendarDayDetailsDto> GetDay(int userId, DateTime date);
    }
}
