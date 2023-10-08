using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Entities;
using TheZ.Shared.DataTransferObjects;

namespace TheZ.Service.Contracts
{

    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChange);
        CompanyDto GetCompany(Guid companyId, bool trackChanges);

    }
}
