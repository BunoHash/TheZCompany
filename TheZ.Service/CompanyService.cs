using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheZ.Contracts.Interfaces;
using TheZ.Entities;
using TheZ.Service.Contracts;
using TheZ.Shared.DataTransferObjects;

namespace TheZ.Service
{
    internal sealed class CompanyService: ICompanyService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repoManager, ILoggerManager logManager, IMapper mapper)
        {
            _logger = logManager;
            _repository = repoManager;
            _mapper = mapper;


        }

        public IEnumerable<CompanyDto>GetAllCompanies(bool trackChange)
        {
            var companies = _repository.Company.GetAllCompanies(trackChange);
            var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companyDto;
        }
    }
}
