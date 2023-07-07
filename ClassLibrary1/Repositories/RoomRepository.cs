using ClassLibrary1.Repositories;
using Microsoft.EntityFrameworkCore;
using Sammy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Core.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(SammysContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Room>> GetAllWithRoomAsync()
        {
            return await MyDbContext.Rooms
                .ToListAsync();
        }

        public Task<Room> GetWithRoomByIdAsync(int id)
        {
            return MyDbContext.Rooms
                .SingleOrDefaultAsync(a => a.RoomId == id);
        }

        private SammysContext MyDbContext
        {
            get { return Context as SammysContext; }
        }
    }
}
