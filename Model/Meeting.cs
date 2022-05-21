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
            Controle.Title();
            Console.Write("Please enter meeting name: ");
            var name = Service.ReadMeetingName();
            Console.Write("Please enter description: ");
            var description = Service.ReadMeetingDescription();
            Category category = Service.SelectMeetingCathegory();
            MeetingType meetingType = Service.SelectMeetingType();
            Console.Write("Please enter start date: ");
            var startDate = Service.ReadDate();
            Console.Write("Please enter end date: ");
            var endDate = Service.ReadEndDate(startDate);
            var person = new Person(Login.user.Name, Login.user.Surname);
            var meeting = new Meeting(name, person, description, category, meetingType, startDate, endDate);
            meeting.Participants.Add(person);

            return meeting;
        }
        public override string ToString()
        {
            return $"Meeting: {Name} - {Description} ({category}, {meetingType}). Organizer: {ResponsiblePerson}" +
                $"\n\tstarts at {startDate} : ends at {endDate}";
        }
    }
}
