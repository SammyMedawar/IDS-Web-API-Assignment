using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Core.Interfaces
{
    public interface IReservationRepository: IRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetAllWithReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
    }
}
