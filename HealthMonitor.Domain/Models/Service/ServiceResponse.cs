namespace HealthMonitor.Domain.Models.Service;

public class ServiceResponse
{
    public bool IsSucces { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }

    //HttpStatusCode 404
}
