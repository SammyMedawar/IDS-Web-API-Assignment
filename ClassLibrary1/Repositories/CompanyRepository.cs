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
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(SammysContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllWithCompaniesAsync()
        {
            return await MyDbContext.Companies
                .ToListAsync();
        }

        public Task<Company> GetWithCompanyIdAsync(int id)
        {
            return MyDbContext.Companies
                .SingleOrDefaultAsync(a => a.CompanyId == id);
        }

        private SammysContext MyDbContext
        {
            get { return Context as SammysContext; }
        }
    }
}
