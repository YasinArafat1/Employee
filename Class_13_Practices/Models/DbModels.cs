using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Class_13_Practices.Models
{

    public enum Grade { M01=1,M02,M03,G01,G02,G03,Ex01,Ex02}
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(Grade))]
        public Grade?  Grade { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set;}
    }
}