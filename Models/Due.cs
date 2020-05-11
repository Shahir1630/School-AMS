using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group03_PS.Models
{
   
    public class Due
    {
        public String MonthName { get; set; }
        public Student student { get; set; }
        public StudentPayment studentPayment { get; set; }
    }
   
}
