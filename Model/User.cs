using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsApp.Model
{
    internal class User
    {
        public string UserName { get; set; }
        public Person person { get; set; }
        public string Password { get; set; }
    }
}
