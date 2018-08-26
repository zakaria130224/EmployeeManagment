using AdventureWork.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWork.Core.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeInfo> GetAllEmployeeInfo();
        EmployeeInfo GetEmployeeInfoById(int Id);
        bool InsertNewEmployeeInfo(EmployeeInfo employeeInfo);
        bool DeleteEmployeeInfoById(int Id);
        bool UpdateEmployeeInfo(EmployeeInfo employeeInfo);


    }
}
