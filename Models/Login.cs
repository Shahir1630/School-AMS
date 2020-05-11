using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group03_PS.Models
{
    public class Login
    {
        public Int64 Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Int64 ActorId { get; set; }
    }
}
