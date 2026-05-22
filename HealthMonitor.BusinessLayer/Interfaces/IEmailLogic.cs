using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IEmailLogic
{
    ServiceResponse SendEmail(string to, string subject, string body);
}
