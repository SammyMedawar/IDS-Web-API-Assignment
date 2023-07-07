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
    public class ReservationRepository: Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(SammysContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Reservation>> GetAllWithReservationsAsync()
        {
            return await MyDbContext.Reservations
                .ToListAsync();
        }

        public Task<Reservation> GetReservationByIdAsync(int id)
        {
            return MyDbContext.Reservations
                .SingleOrDefaultAsync(a => a.UserId == id);
        }

        private SammysContext MyDbContext
        {
            get { return Context as SammysContext; }
        }
    }
}
