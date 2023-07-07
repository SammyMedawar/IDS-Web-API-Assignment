using ClassLibrary1.Interfaces;
using Sammy.Core.Interfaces;
using Sammy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace ClassLibrary1.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SammysContext _context;
        private SystemUserRepository _systemUserRepository;
        private CompanyRepository _companyRepository;
        private RoomRepository _roomRepository;
        private ReservationRepository _reservationRepository;

        public UnitOfWork(SammysContext context)
        {
            this._context = context;
        }

        public ISystemUserRepository systemUsers => _systemUserRepository = _systemUserRepository ?? new SystemUserRepository(_context);

        public ICompanyRepository companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);

        public IRoomRepository rooms => _roomRepository = _roomRepository ?? new RoomRepository(_context);

        public IReservationRepository reservations => _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
