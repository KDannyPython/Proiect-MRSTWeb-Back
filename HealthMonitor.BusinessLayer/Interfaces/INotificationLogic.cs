using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Notification;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface INotificationLogic
    {
        ServiceResponse CreateNotification(CreateNotificationDto notification);
        ServiceResponse GetNotificationById(int Id);
        ServiceResponse GetNotificationByUserId(int userId);
        ServiceResponse MarkAllAsRead(int userId);
        ServiceResponse MarkAsRead(int Id);
        ServiceResponse DeleteNotification(int Id);
    }
}
