using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWork.Core.Entity
{
    [Table("EmployeeAttendance")]
    public class EmployeeAttendance
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public TimeSpan CheckIn { get; set; } //? DataType
        public TimeSpan CheckOut { get; set; } //? DataType
        public TimeSpan Duration { get; set; } //? DataType
        public DateTime CreatedOn { get; set; }

    }
}
