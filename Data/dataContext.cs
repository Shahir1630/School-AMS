using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group03_PS.Models;
using Microsoft.EntityFrameworkCore;

namespace Group03_PS.Data
{
    public class dataContext : DbContext
    {

        public dataContext(DbContextOptions<dataContext> options)
        : base(options)
        {



        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentPayment>StudentPayment { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherPayment> TeacherPayment { get; set; }
       
        
        
    }
}