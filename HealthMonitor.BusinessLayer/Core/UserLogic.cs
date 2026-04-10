using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.User;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Core
{
    public class UserLogic : UserActions, IUserLogic
    {
        public ServiceResponse CreateUser(UserCreateDto userDto)
        {
            var result = CreateUserAction(userDto);
            if (result == false)
            {
                return new ServiceResponse
                {
                    IsSucces = false,
                    Message = "A apărut o eroare. Utilizatorul nu a putut fi creat."
                };
            }
            return new ServiceResponse
            {
                IsSucces = true,
                Message = "Utilizatorul a fost creat cu succes."
            };
        }

        public ServiceResponse GetUserById(int id)
        {
            var user = GetUserByIdAction(id);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSucces = false,
                    Message = "Utilizatorul nu a fost găsit în baza de date."
                };
            }

            return new ServiceResponse
            {
                IsSucces = true,
                Data = user
            };
        }

        public ServiceResponse GetUserList()
        {
            var userList = GetUserListAction();
            return new ServiceResponse
            {
                IsSucces = true,
                Data = userList
            };
        }

        public ServiceResponse UpdateUser(int id, UserCreateDto userDto)
        {
            var result = UpdateUserAction(id, userDto);
            if (result == false)
            {
                return new ServiceResponse
                {
                    IsSucces = false,
                    Message = "Utilizatorul nu a fost găsit sau a apărut o eroare la actualizare."
                };
            }
            return new ServiceResponse
            {
                IsSucces = true,
                Message = "Informațiile utilizatorului au fost actualizate cu succes."
            };
        }

        public ServiceResponse DeleteUser(int id)
        {
            var result = DeleteUserAction(id);
            if (result == false)
            {
                return new ServiceResponse
                {
                    IsSucces = false,
                    Message = "Utilizatorul nu a putut fi șters sau nu a fost găsit."
                };
            }
            return new ServiceResponse
            {
                IsSucces = true,
                Message = "Utilizatorul a fost șters cu succes din baza de date."
            };
        }
    }
}
