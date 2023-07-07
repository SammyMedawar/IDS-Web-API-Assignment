using ClassLibrary1.Interfaces;
using Sammy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Company> CreateCompany(Company newCompany)
        {
            await _unitOfWork.companies.AddAsync(newCompany);
            await _unitOfWork.CommitAsync();
            return newCompany;
        }

        public async Task DeleteCompany(Company newCompany)
        {
            _unitOfWork.companies.Remove(newCompany);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAllWithCompanies()
        {
            return await _unitOfWork.companies
                .GetAllWithCompaniesAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _unitOfWork.companies
                .GetWithCompanyIdAsync(id);
        }

        public async Task updateCompany(Company oldCompany, Company newCompany)
        {
            oldCompany.Name = newCompany.Name;
            oldCompany.Description = newCompany.Email;
            oldCompany.Email = newCompany.Email;
            oldCompany.Logo = newCompany.Logo;
            oldCompany.Active = newCompany.Active;
            oldCompany.RelatedUser = newCompany.RelatedUser;

            await _unitOfWork.CommitAsync();
        }
    }
}
