using ClassLibrary1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace ClassLibrary1.Repositories
{
    public class SystemUserRepository : Repository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(SammysContext context)
            : base(context)
        { }

        public async Task<IEnumerable<SystemUser>> GetAllWithSystemUsersAsync()
        {
            return await MyDbContext.SystemUsers
                .ToListAsync();
        }

        public Task<SystemUser> GetWithSystemUserByIdAsync(int id)
        {
            return MyDbContext.SystemUsers
                .SingleOrDefaultAsync(a => a.UserId == id);
        }

        private SammysContext MyDbContext
        {
            get { return Context as SammysContext; }
        }
    }
}
