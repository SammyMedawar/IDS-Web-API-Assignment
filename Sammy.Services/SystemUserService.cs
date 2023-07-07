using ClassLibrary1.Interfaces;
using Sammy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Services
{
    public class SystemUserService : ISystemUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SystemUserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<SystemUser> CreateSystemUser(SystemUser newSystemUser)
        {
            await _unitOfWork.systemUsers.AddAsync(newSystemUser);
            await _unitOfWork.CommitAsync();
            return newSystemUser;
        }

        public async Task DeleteSystemUser(SystemUser newSystemUser)
        {
            _unitOfWork.systemUsers.Remove(newSystemUser);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<SystemUser>> GetAllWithSystemUsers()
        {
            return await _unitOfWork.systemUsers
                .GetAllWithSystemUsersAsync();
        }

        public async Task<SystemUser> GetSystemUserById(int id)
        {
            return await _unitOfWork.systemUsers
                .GetWithSystemUserByIdAsync(id);
        }

        public async Task updateSystemUser(SystemUser oldSystemUser, SystemUser newSystemUser)
        {
            oldSystemUser.DateOfBirth = newSystemUser.DateOfBirth;
            oldSystemUser.Gender = newSystemUser.Gender;
            oldSystemUser.Password = newSystemUser.Password;
            oldSystemUser.CompanyId = newSystemUser.CompanyId;

            await _unitOfWork.CommitAsync();
        }
    }
}
