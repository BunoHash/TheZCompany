using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Contracts.Interfaces;
using TheZ.Entities;
using TheZ.Entities.Exceptions;
using TheZ.Service.Contracts;
using TheZ.Shared.DataTransferObjects;

namespace TheZ.Service
{
    public sealed class EmployeeService: IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public EmployeeService(IRepositoryManager repoManager, ILoggerManager logManager, IMapper mapper)
        {
            _logger = logManager;
            _repository = repoManager;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChange)
        {
            var company = _repository.Company.GetCompany(companyId, trackChange);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChange);
            if (employeesFromDb is null)
                throw new EmployeeNotFoundException(companyId);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;

        }

        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges);
            if (employeeDb is null)
                throw new EmployeeNotFoundException(id);
            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }

    }
}
