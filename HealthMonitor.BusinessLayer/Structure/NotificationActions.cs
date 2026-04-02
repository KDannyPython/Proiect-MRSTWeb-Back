using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Notification;
using HealthMonitor.Domain.Models.Notification;
namespace HealthMonitor.BusinessLayer.Structure;

public class NotificationActions
{
    private readonly AppDbContext _context;

    public NotificationActions()
    {
        _context = new AppDbContext();
    }

    public bool CreateNotificationAction(CreateNotificationDto notification)
    {
        var notificationEntity = new NotificationEntity
        {
            UserId = notification.UserId,
            Name = notification.Name,
            Description = notification.Description,
            IsRead = false,
            CreatedAt = DateTime.UtcNow
        };

        try
        {
            _context.Add(notificationEntity);
            _context.SaveChanges();
            return true;
        }

        catch (Exception e)
        {
            return false;
        }
    }

    public NotificationInfoDto? GetNotificationByIdAction(int Id)
    {
        var notificationEntity = _context.Notification.Find(Id);
        if (notificationEntity == null)
        {
            return null;
        }

        var notificationInfoDto = new NotificationInfoDto
        {
            Id = notificationEntity.Id,
            UserId = notificationEntity.UserId,
            Name = notificationEntity.Name,
            Description = notificationEntity.Description,
            IsRead = notificationEntity.IsRead,
            CreatedAt = notificationEntity.CreatedAt
        };

        return notificationInfoDto;
    }

    public List<NotificationInfoDto> GetNotificationByUserIdAction(int userId)
    {
        var notificationList = _context.Notification
            .Where(n => n.UserId == userId)
            .Select(n => new NotificationInfoDto
            {
                Id = n.Id,
                UserId = n.UserId,
                Name = n.Name,
                Description = n.Description,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            })
            .ToList();
        return notificationList;
    }

    public bool MarkAllAsReadAction(int userId)
    {
        var notifications = _context.Notification.Where(n => n.UserId == userId && !n.IsRead).ToList();
        if (!notifications.Any())
        {
            return false;
        }
        try
        {
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool MarkAsReadAction(int Id)
    {
        var notificationEntity = _context.Notification.Find(Id);
        if (notificationEntity == null)
        {
            return false;
        }
        try
        {
            notificationEntity.IsRead = true;
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteNotificationAction(int Id)
    {
        var notificationEntity = _context.Notification.Find(Id);

        if (notificationEntity == null)
        {
            return false;
        }

        try
        {
            _context.Remove(notificationEntity);
            _context.SaveChanges();
            return true;
        }

        catch (Exception e)
        {
            return false;
        }
    }

}
