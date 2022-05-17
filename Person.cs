using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsApp
{
    internal class Person
    {
        private readonly string _name;
        private readonly string _surname;

        public Person(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }
    }
}
