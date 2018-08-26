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
    public class EmployeeAttendanceRepository : IEmployeeAttendanceRepository
    {
        private readonly DatabaseContext _context;

        public EmployeeAttendanceRepository()
        {
            _context = new DatabaseContext();
        }
        public bool DeleteEmployeeAttendanceById(int Id)
        {
            _context.EmployeeAttendance.Remove(_context.EmployeeAttendance.Single(a => a.Id == Id));
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<EmployeeAttendance> GetAllEmployeeAttendance()
        {
            return _context.EmployeeAttendance.ToList();
        }

        public EmployeeAttendance GetEmployeeAttendanceById(int Id)
        {
            return _context.EmployeeAttendance.Single(a => a.Id == Id);
        }

        public bool InsertNewEmployeeAttendance(EmployeeAttendance employeeAttendance)
        {
            _context.EmployeeAttendance.Add(employeeAttendance);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateEmployeeAttendance(EmployeeAttendance employeeAttendance)
        {
            var emp = _context.EmployeeAttendance.Single(c => c.Id == employeeAttendance.Id);
            emp.CheckIn = employeeAttendance.CheckIn;
            emp.CheckOut = employeeAttendance.CheckOut;
            emp.Duration = employeeAttendance.Duration;
            _context.SaveChanges();
            return true;
        }
    }
}
