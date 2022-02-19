using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        
        public ReportingStructure Create(string id)
        {
            Employee e = _employeeService.GetById(id);
            return new ReportingStructure()
            {  
                ParentEmployee = e,
                NumberOfReports = 0
            };
        }
        
    }
}
