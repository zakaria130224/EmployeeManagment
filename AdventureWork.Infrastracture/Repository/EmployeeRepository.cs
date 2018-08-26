using AdventureWork.Core.Entity;
using AdventureWork.Core.Repository;
using AdventureWork.Infrastracture.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWork.Infrastracture.Repository
{
    public class EmployeeRepository : Core.Repository.IEmployeeRepository
    {
        private readonly DatabaseContext _context;

        public EmployeeRepository()
        {
            _context = new DatabaseContext();
        }

        public bool DeleteEmployeeInfoById(int Id)
        {
            //var empList = _context.EmployeeAttendance.Where(x => x.EmployeeId == Id).ToList();
            //foreach (var item in empList)
            //{
            //    _context.EmployeeAttendance.Remove(item);
            //    _context.SaveChanges();
            //}
            _context.EmployeeInfo.Remove(_context.EmployeeInfo.Single(a => a.Id == Id));
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<EmployeeInfo> GetAllEmployeeInfo()
        {
           
            return _context.EmployeeInfo.ToList();
        }

        public EmployeeInfo GetEmployeeInfoById(int Id)
        {
            return _context.EmployeeInfo.Single(a => a.Id == Id);
        }

        public bool InsertNewEmployeeInfo(EmployeeInfo employeeInfo)
        {
            _context.EmployeeInfo.Add(employeeInfo);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            var emp = _context.EmployeeInfo.Single(c => c.Id == employeeInfo.Id);
            emp.FullName = employeeInfo.FullName;
            emp.Email = employeeInfo.Email;
            emp.Address = employeeInfo.Address;
            emp.Mobile = employeeInfo.Mobile;
            _context.SaveChanges();
            return true;
            
        }

    
    }
}
