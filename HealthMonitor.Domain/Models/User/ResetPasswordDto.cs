using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.User;

public class ResetPasswordDto
{
    [EmailAddress]
    public string Email { get; set; }
    [Range(100000, 999999)]
    public string Code { get; set; }
    public string NewPassword { get; set; }
}
