using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Group03_PS.Models;

namespace Group03_PS.ViewModels
{
    public class LoginVM
    {
        public Int64 Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Int64 ActorId { get; set; }

    }
}
