using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.User;

public class ForgotPasswordDto
{
    [EmailAddress]
    public string Email { get; set; }
}
