using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group03_PS.Models
{
    public class TeacherPayment
    {
        public DateTime Date { get; set; }
        public Int64 TeacherId { get; set; }
        public Int64 Salary { get; set; }
        public Int64 Fine { get; set; }
        public string MonthName { get; set; }
        [Key]
        public Int64 No { get; set; }
    }
}
