using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Entity;

namespace JobBoard.Dao
{
    public interface ICompanyService
    {
        void RegisterCompany(Company company);
        List<Company> GetAllCompanies();
        Company GetCompanyById(int companyId);
    }
}
