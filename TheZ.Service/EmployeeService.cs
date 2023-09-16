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

    }
}
