using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Service.Contracts;

namespace TheZ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController: ControllerBase
    {
        public readonly IServiceManager _serviceManager;
        public CompaniesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            
            var companies = _serviceManager.CompanyService.GetAllCompanies(false);
            return Ok(companies);
        }
    }
}
