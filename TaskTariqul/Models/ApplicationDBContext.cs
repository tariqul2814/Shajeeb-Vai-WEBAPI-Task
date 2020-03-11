using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskTariqul.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

    }
}