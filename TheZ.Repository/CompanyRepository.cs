using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Contracts.Interfaces;
using TheZ.Entities;

namespace TheZ.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChange)
        {
            throw new Exception("Exception");
            return FindAll(trackChange).OrderBy(c => c.Name).ToList();
        }
        
    }
}
