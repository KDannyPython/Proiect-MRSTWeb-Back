using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.User;

public class VerifyTwoFactorDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Code { get; set; }
}
