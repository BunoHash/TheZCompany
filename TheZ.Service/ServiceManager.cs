using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Contracts.Interfaces;
using TheZ.Service.Contracts;

namespace TheZ.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper _mapper)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repository, logger, _mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, logger, _mapper));

        }

        public ICompanyService CompanyService => _companyService.Value;

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
