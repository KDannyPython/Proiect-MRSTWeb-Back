using Microsoft.AspNetCore.Mvc;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer;
using HealthMonitor.Domain.Models.Notification;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/notification")]
public class NotificationController : ControllerBase
{
    private readonly INotificationLogic _notificationLogic;

    public NotificationController()
    {
        var bl = new BusinessLogic();
        _notificationLogic = bl.GetNotificationLogic();
    }

    [HttpPost("create")]
    public IActionResult CreateNotification([FromBody] CreateNotificationDto notification)
    {
        var result = _notificationLogic.CreateNotification(notification);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }

    [HttpGet("search/{Id}")]
    public IActionResult GetNotificationById(int Id)
    {
        var result = _notificationLogic.GetNotificationById(Id);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet("list/{UserId}")]
    public IActionResult GetNotificationByUserId(int UserId)
    {
        var result = _notificationLogic.GetNotificationByUserId(UserId);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Data);
    }

    [HttpPut("markAllAsRead/{UserId}")]
    public IActionResult MarkAllAsRead([FromRoute] int UserId)
    {
        var result = _notificationLogic.MarkAllAsRead(UserId);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }

    [HttpPut("markAsRead/{Id}")]
    public IActionResult MarkAsRead(int Id)
    {
        var result = _notificationLogic.MarkAsRead(Id);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteNotification(int Id)
    {
        var result = _notificationLogic.DeleteNotification(Id);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }   
}