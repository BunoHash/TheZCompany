using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Shared.DataTransferObjects;

namespace TheZ.Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChange);
        EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChange);
    }
}
