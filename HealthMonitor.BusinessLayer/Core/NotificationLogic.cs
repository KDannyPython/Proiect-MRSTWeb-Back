using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Notification;
using HealthMonitor.Domain.Models.Service;
namespace HealthMonitor.BusinessLayer.Core;

public class NotificationLogic : NotificationActions, INotificationLogic
{
    public ServiceResponse CreateNotification(CreateNotificationDto notification)
    {
        var result = CreateNotificationAction(notification);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Failed to create notification."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Notification created successfully."
        };
    }

    public ServiceResponse GetNotificationById(int Id)
    {
        var notification = GetNotificationByIdAction(Id);
        if (notification == null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Notification not found."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Data = notification
        };
    }

    public ServiceResponse GetNotificationByUserId(int userId)
    {
        var notifications = GetNotificationByUserIdAction(userId);
        if (notifications == null || notifications.Count == 0)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "No notifications found for this user."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Data = notifications
        };
    }

    public ServiceResponse MarkAllAsRead(int UserId)
    {
        var result = MarkAllAsReadAction(UserId);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Failed to mark notifications as read."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "All notifications marked as read successfully."
        };
    }

    public ServiceResponse MarkAsRead(int Id)
    {
        var result = MarkAsReadAction(Id);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Failed to mark notification as read."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Notification marked as read successfully."
        };
    }

    public ServiceResponse DeleteNotification(int Id)
    {
        var result = DeleteNotificationAction(Id);
        if (result == false)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Failed to delete notification."
            };
        }
        return new ServiceResponse
        {
            IsSuccess = true,
            Message = "Notification deleted successfully."
        };
    }
}
