using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.Admin;
using HealthMonitor.Domain.Models.Service;

namespace HealthMonitor.BusinessLayer.Core
{
    public class AdminLogic : AdminActions, IAdminLogic
    {
        public ServiceResponse CreateAdmin(AdminCreateDto adminDto)
        {
            var result = CreateAdminAction(adminDto);
            if (result == false)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "A apărut o eroare. Administratorul nu a putut fi creat."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Administratorul a fost creat cu succes."
            };
        }

        public ServiceResponse GetAdminById(int id)
        {
            var admin = GetAdminByIdAction(id);
            if (admin == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Administratorul nu a fost găsit în baza de date."
                };
            }

            return new ServiceResponse
            {
                IsSuccess = true,
                Data = admin
            };
        }

        public ServiceResponse GetAdminList()
        {
            var adminList = GetAdminListAction();
            return new ServiceResponse
            {
                IsSuccess = true,
                Data = adminList
            };
        }

        public ServiceResponse UpdateAdmin(int id, AdminCreateDto adminDto)
        {
            var result = UpdateAdminAction(id, adminDto);
            if (result == false)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Administratorul nu a fost găsit sau a apărut o eroare la actualizare."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Informațiile administratorului au fost actualizate cu succes."
            };
        }

        public ServiceResponse DeleteAdmin(int id)
        {
            var result = DeleteAdminAction(id);
            if (result == false)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Administratorul nu a putut fi șters sau nu a fost găsit."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Administratorul a fost șters cu succes din baza de date."
            };
        }
    }
}
