using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.User;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Core
{
    public class UserLogic : UserActions, IUserLogic
    {
        public ServiceResponse GetUserById(int id)
        {
            var user = GetUserByIdAction(id);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Utilizatorul nu a fost găsit în baza de date."
                };
            }

            return new ServiceResponse
            {
                IsSuccess = true,
                Data = user
            };
        }

        public ServiceResponse GetUserList()
        {
            var userList = GetUserListAction();
            return new ServiceResponse
            {
                IsSuccess = true,
                Data = userList
            };
        }

        public async Task UpdateMe(int userId, UpdateUserDto userDto)
        {
            var result = UpdateMeAction(userId, userDto);
        }

        public ServiceResponse UpdateUser(int id, UserCreateDto userDto)
        {
            var result = UpdateUserAction(id, userDto);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Utilizatorul nu a fost găsit sau a apărut o eroare la actualizare."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Informațiile utilizatorului au fost actualizate cu succes."
            };
        }

        public ServiceResponse DeleteUser(int id)
        {
            var result = DeleteUserAction(id);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Utilizatorul nu a putut fi șters sau nu a fost găsit."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Utilizatorul a fost șters cu succes din baza de date."
            };
        }
    }
}
