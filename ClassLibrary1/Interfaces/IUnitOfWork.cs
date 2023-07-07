using Sammy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISystemUserRepository systemUsers { get; }
        ICompanyRepository companies { get; }
        IRoomRepository rooms { get; }
        IReservationRepository reservations { get; }

        Task<int> CommitAsync();
    }
}
