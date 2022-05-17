using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeetingsApp.DataTypes;

namespace MeetingsApp
{
    internal class Metting
    {
        private readonly string _name;
        private readonly Person _responsiblePerson;
        private readonly string _description;
        private readonly Category _category;
        private readonly MeetingType _type;
        private readonly DateOnly _startDate;
        private readonly DateOnly _endDate;
        private List<Person> Participants;

        private Metting(string name, Person responsiblePerson, string description, Category category, MeetingType type, DateOnly startDate, DateOnly endDate)
        {
            _name = name;
            _responsiblePerson = responsiblePerson;
            _description = description;
            _category = category;
            _type = type;
            _startDate = startDate;
            _endDate = endDate;
        }

        public void Create()
        {
            Console.WriteLine("Please enter meeting name:");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter responsible person name:");
            var personName = Console.ReadLine();
            Console.WriteLine("Please enter responsible person surname:");
            var surname = Console.ReadLine();
            Category category = Service.SelectMeetingCathegory();

            var meeting = new Metting(name, new Person(personName, surname), category);
        }
    }
}
