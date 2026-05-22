using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.User;

public class VerifyTwoFactorDto
{
    [EmailAddress]
    public string Email { get; set; }

    [Range(1000, 9999)]
    public string Code { get; set; }
}
