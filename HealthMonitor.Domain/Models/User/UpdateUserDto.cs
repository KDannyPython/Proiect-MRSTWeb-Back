using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.User;

public class UpdateUserDto
{
    public string? Name { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public string? Goal { get; set; }

    public string? Bio { get; set; }

    public bool? TwoFactorEnabled { get; set; }
}
