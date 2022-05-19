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
        public String Name { get; set; }
        public Person ResponsiblePerson { get; set; }
        public String Description { get; set; }
        public Category category { get; set; }
        public MeetingType meetingType { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public List<Person> Participants = new List<Person>();

        public Meeting(string name, Person responsiblePerson, string description, Category category, MeetingType type, DateOnly startDate, DateOnly endDate)
        {
            Name = name;
            ResponsiblePerson = responsiblePerson;
            Description = description;
            this.category = category;
            meetingType = type;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public static Meeting Create()
        {
            Console.Clear();
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
