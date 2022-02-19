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
            var parentEmployee = _employeeService.GetById(id);

            var reportsCount = GetReportingCount(parentEmployee);
            
            return new ReportingStructure()
            {  
                NumberOfReports = reportsCount,
                Manager = parentEmployee
            };
        }

        private int GetReportingCount(Employee e)
        {
            int directReportsCount = e.DirectReports.Count;
            
            foreach (var employeeRef in e.DirectReports)
            {
                Employee employee = _employeeService.GetById(employeeRef.EmployeeId);
                directReportsCount += GetReportingCount(employee);
            }
            
            return directReportsCount;
        }
        
    }
}
