using AdventureWork.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWork.Core.Services
{
    public interface IEmployeeRepositoryServices
    {
        List<EmployeeInfo> GetEmployees();
        EmployeeInfo GetEmployeeById(int Id);
        bool AddNewEmployee(EmployeeInfo emp);
        bool DeleteEmployeeById(int Id);
        bool EditEmployeeById(EmployeeInfo employeeInfo);
        IEnumerable<EmployeeAttendance> GetEmployeeAttendancesByEmployeeId(int Id);
    }
}
