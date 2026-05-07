using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IUserLogic
    {
        ServiceResponse GetUserById(int id);
        ServiceResponse GetUserList();
        ServiceResponse UpdateUser(int id, UserCreateDto user);
        ServiceResponse DeleteUser(int id);
    }
}
