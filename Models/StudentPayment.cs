using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Group03_PS.Models
{
    public class StudentPayment
    {
        public DateTime Date { get; set; }
        public Int64 Id { get; set; }
        public Int64 AdmissionFee { get; set; }
        public Int64 ReAdmission { get; set; }
        public Int64 YearlyCharge { get; set; }
        public Int64 Examination { get; set; }
        public Int64 Lab { get; set; }
        public Int64 IdCard { get; set; }
        public Int64 Other { get; set; }
        public Int64 TuitionFee { get; set; }
        public Int64 Fine { get; set; }
        public string MonthName { get; set; }
        public Int64 AdvancePayment { get; set; }
        [Key]
        public Int64 No { get; set; }

    }


}
