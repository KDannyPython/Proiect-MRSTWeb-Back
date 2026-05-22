namespace HealthMonitor.Domain.Models.User;

public class UpdateUserDto
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public string? Goal { get; set; }
}
