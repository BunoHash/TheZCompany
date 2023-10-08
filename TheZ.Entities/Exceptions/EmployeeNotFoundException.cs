using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZ.Entities.Exceptions
{
    public class EmployeeNotFoundException: NotFoundException
    {
        public EmployeeNotFoundException(Guid companyId)
            : base($"No employee found for company {companyId}")
        {
            
        }
    }
}
