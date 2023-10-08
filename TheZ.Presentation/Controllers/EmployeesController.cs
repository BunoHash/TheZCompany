using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Service.Contracts;
using TheZ.Entities.Exceptions;

namespace TheZ.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController: ControllerBase
    {
        private readonly IServiceManager _services;
        public EmployeesController(IServiceManager manager) => _services = manager;

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _services.EmployeeService.GetEmployees(companyId, false);
            return Ok(employees);

        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = _services.EmployeeService.GetEmployee(companyId, id, trackChange: false);
            return Ok(employee);
        }

    }
}
