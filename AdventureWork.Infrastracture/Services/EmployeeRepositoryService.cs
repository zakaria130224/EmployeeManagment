using AdventureWork.Core.Entity;
using AdventureWork.Core.Services;
using AdventureWork.Infrastracture.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWork.Infrastracture.Services
{
    public class EmployeeRepositoryService : IEmployeeRepositoryServices
    {
       // private EmployeeRepository employeeRepository;
        //private EmployeeAttendanceRepository employeeAttendanceRepository;

        private Repository<EmployeeAttendance> employeeAttendanceRepository;
        private Repository<EmployeeInfo> employeeRepository;
      

        public EmployeeRepositoryService()
        {
          
            employeeRepository = new Repository<EmployeeInfo>();
            employeeAttendanceRepository = new Repository<EmployeeAttendance>();

            // employeeRepository = new EmployeeRepository();
            // employeeAttendanceRepository = new EmployeeAttendanceRepository();
            //this.employeeRepository = employeeRepository;
            //this.employeeAttendanceRepository = employeeAttendanceRepository;
        }

        public bool AddNewEmployee(EmployeeInfo emp)
        {
            if (employeeRepository.Insert(emp))
                return true;
            return false;

        }

        public bool DeleteEmployeeById(int Id)
        {
            var empAttendanceList = employeeAttendanceRepository.GetAll().Where(x => x.EmployeeId == Id);

            foreach (var item in empAttendanceList)
            {
                employeeAttendanceRepository.Delete(item.Id);
            }
            employeeRepository.Delete(Id);
            return true;
          
        }

        public bool EditEmployeeById(EmployeeInfo employeeInfo)
        {
            if (employeeRepository.Update(employeeInfo))
                return true;
            return false;
        }

        public IEnumerable<EmployeeAttendance> GetEmployeeAttendancesByEmployeeId(int Id)
        {
            return employeeAttendanceRepository.GetAll().Where(x => x.EmployeeId == Id);
        }

        public EmployeeInfo GetEmployeeById(int Id)
        {
            return employeeRepository.Get(Id);
        }

        public List<EmployeeInfo> GetEmployees()
        {
           return employeeRepository.GetAll().ToList();
        }
    }
}
