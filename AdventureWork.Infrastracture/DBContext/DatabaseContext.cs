using AdventureWork.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWork.Infrastracture.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }

        public DatabaseContext()
            : base("name=DatabaseContext")
        {

        }

        //TODO: How this method works and why? 
        /*
         * This happens when your table structure and model class no longer in sync.
         * This method will turn off all the initialization, disabling the migrations as well.
         */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DatabaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
