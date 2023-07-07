using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllWithRooms();
    }
}
