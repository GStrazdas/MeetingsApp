using MeetingsApp.Services;
using static MeetingsApp.Model.DataTypes;

namespace MeetingsApp.Model
{
    public class Meeting
    {
        public string Name { get; set; }
        public Person ResponsiblePerson { get; set; }
        public string Description { get; set; }
        public Category category { get; set; }
        public MeetingType meetingType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<Person> Participants = new List<Person>();

        public Meeting(string name, Person responsiblePerson, string description, Category category, MeetingType type, DateTime startDate, DateTime endDate)
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
            Console.Write("Please enter meeting name:");
            var name = Service.ReadMeetingName();
            Console.Write("\nPlease enter responsible person name:");
            var personName = Console.ReadLine();
            Console.Write("\nPlease enter responsible person surname:");
            var surname = Console.ReadLine();
            Console.Write("\nPlease enter description:");
            var description = Service.ReadMeetingDescription();
            Category category = Service.SelectMeetingCathegory();
            MeetingType meetingType = Service.SelectMeetingType();
            Console.Write("\nPlease enter start date:");
            var startDate = Service.ReadDate();
            Console.Write("\nPlease enter end date:");
            var endDate = Service.ReadEndDate(startDate);

            return new Meeting(name, new Person(personName, surname), description, category, meetingType, startDate, endDate);
        }

        public override string ToString()
        {
            return $"Meeting: {Name} - {Description} ({category}, {meetingType}) organizer {ResponsiblePerson}" +
                $"\n\tstarts at {startDate} : ends at {endDate}";
        }
    }
}
