using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.BusinessLayer.Structure;

namespace HealthMonitor.BusinessLayer.Core;

public class EmailLogic : EmailActions, IEmailLogic
{
    public ServiceResponse SendEmail(string to, string subject, string body)
    {
        var result = SendEmailAction(to, subject, body);

        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Failed to send email."
            };
        }

        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Email sent successfully."
        };
    }
}
