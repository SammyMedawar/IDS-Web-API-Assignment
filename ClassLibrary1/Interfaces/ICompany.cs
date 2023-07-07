using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Core.Interfaces
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllWithCompaniesAsync();
        Task<Company> GetWithCompanyIdAsync(int id);
    }
}
