using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Core.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IEnumerable<Room>> GetAllWithRoomAsync();
        Task<Room> GetWithRoomByIdAsync(int id);
    }
}
