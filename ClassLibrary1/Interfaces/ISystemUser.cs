
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace ClassLibrary1.Interfaces
{
    public interface ISystemUserRepository : IRepository<SystemUser>
    {
        Task<IEnumerable<SystemUser>> GetAllWithSystemUsersAsync();
        Task<SystemUser> GetWithSystemUserByIdAsync(int id);

    }
}
