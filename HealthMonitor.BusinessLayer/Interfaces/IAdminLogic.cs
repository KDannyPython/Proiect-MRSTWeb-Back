using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Admin;
using HealthMonitor.Domain.Entities.Admin;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IAdminLogic
    {
        ServiceResponse CreateAdmin(AdminCreateDto admin);
        ServiceResponse GetAdminById(int id);
        ServiceResponse GetAdminList();
        ServiceResponse UpdateAdmin(int id, AdminCreateDto admin);
        ServiceResponse DeleteAdmin(int id);
        Admin? LoginAdminAction(UserLoginDto loginDto);
        string AdminTokenGeneration(Admin admin);
    }
}
