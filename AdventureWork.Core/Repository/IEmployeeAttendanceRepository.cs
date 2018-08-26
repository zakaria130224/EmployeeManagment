using AdventureWork.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWork.Core.Repository
{
    public interface IEmployeeAttendanceRepository
    {
        IEnumerable<EmployeeAttendance> GetAllEmployeeAttendance();
        EmployeeAttendance GetEmployeeAttendanceById(int Id);
        bool InsertNewEmployeeAttendance(EmployeeAttendance employeeAttendance);
        bool DeleteEmployeeAttendanceById(int Id);
        bool UpdateEmployeeAttendance(EmployeeAttendance employeeAttendance);
    }
}
