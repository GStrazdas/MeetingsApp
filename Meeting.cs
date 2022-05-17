using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeetingsApp.DataTypes;

namespace MeetingsApp
{
    internal class Meeting
    {
        private readonly string _name;
        private readonly Person _responsiblePerson;
        private readonly string _description;
        private readonly Category _category;
        private readonly MeetingType _type;
        private readonly DateOnly _startDate;
        private readonly DateOnly _endDate;
        private List<Person> Participants;

        private Meeting(string name, Person responsiblePerson, string description, Category category, MeetingType type, DateOnly startDate, DateOnly endDate)
        {
            _name = name;
            _responsiblePerson = responsiblePerson;
            _description = description;
            _category = category;
            _type = type;
            _startDate = startDate;
            _endDate = endDate;
        }

        public static Meeting Create()
        {
            Console.WriteLine("Please enter meeting name:");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter responsible person name:");
            var personName = Console.ReadLine();
            Console.WriteLine("Please enter responsible person surname:");
            var surname = Console.ReadLine();
            Console.WriteLine("Please enter description:");
            var description = Console.ReadLine();
            Category category = Service.SelectMeetingCathegory();
            MeetingType meetingType = Service.SelectMeetingType();
            Console.WriteLine("Please enter starting date:");
            Console.WriteLine("Please enter start date:");
            var startDate = Service.ReadDate();
            Console.WriteLine("Please enter end date:");
            DateOnly endDate;
            do
            {
                endDate = Service.ReadDate();
                if (endDate >= startDate)
                {
                    break;
                }
                Console.WriteLine("The end date should be greater or equal to the start date!");
            }
            while (true);

            var meeting = new Meeting(name, new Person(personName, surname), description, category, meetingType, startDate, endDate);
            return meeting;
        }
    }
}
