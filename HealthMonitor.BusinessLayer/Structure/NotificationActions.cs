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

        var moldovaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Chisinau");
        var notificationInfoDto = new NotificationInfoDto
        {
            Id = notificationEntity.Id,
            UserId = notificationEntity.UserId,
            Name = notificationEntity.Name,
            Description = notificationEntity.Description,
            IsRead = notificationEntity.IsRead,
            CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(
                notificationEntity.CreatedAt,
                moldovaTimeZone
                ),
        };

        return notificationInfoDto;
    }

    public List<NotificationInfoDto> GetNotificationByUserIdAction(int userId)
    {
        var moldovaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Chisinau");
        var notificationList = _context.Notification
            .Where(notificationEntity => notificationEntity.UserId == userId)
            .Select(notificationEntity => new NotificationInfoDto
            {
                Id = notificationEntity.Id,
                UserId = notificationEntity.UserId,
                Name = notificationEntity.Name,
                Description = notificationEntity.Description,
                IsRead = notificationEntity.IsRead,
                CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(
                    notificationEntity.CreatedAt,
                    moldovaTimeZone
                    ),
            })
            .ToList();
        return notificationList;
    }

    public bool MarkAllAsReadAction(int UserId)
    {
        var notifications = _context.Notification.Where(n => n.UserId == UserId && !n.IsRead).ToList();
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
