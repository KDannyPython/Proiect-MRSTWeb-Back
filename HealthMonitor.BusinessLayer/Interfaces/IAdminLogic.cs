using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Admin;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IAdminLogic
    {
        ServiceResponse CreateAdmin(AdminCreateDto admin);
        ServiceResponse GetAdminById(int id);
        ServiceResponse GetAdminList();
        ServiceResponse UpdateAdmin(int id, AdminCreateDto admin);
        ServiceResponse DeleteAdmin(int id);
    }
}
