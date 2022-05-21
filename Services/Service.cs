using MeetingsApp.Model;
using Newtonsoft.Json;
using static MeetingsApp.Model.DataTypes;

namespace MeetingsApp.Services
{
    internal class Service
    {
        public static Category SelectMeetingCathegory()
        {
            Console.WriteLine("Please select meeting category:" +
                "\n0 - CodeMonkey" +
                "\n1 - Hub" +
                "\n2 - Short" +
                "\n3 - TeamBuilding");
            Category category;
            do
                try
                {
                    category = (Category)int.Parse(Console.ReadLine());
                    if ((int)category >= 0 && (int)category <= 3)
                    {
                        break;
                    }
                    Console.WriteLine("Please select one more time:");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            while (true);
            return category;
        }
        public static MeetingType SelectMeetingType()
        {
            Console.WriteLine("Please select meeting type:" +
                "\n0 - Live" +
                "\n1 - InPerson");
            MeetingType meetingType;
            do
                try
                {
                    meetingType = (MeetingType)int.Parse(Console.ReadLine());
                    if ((int)meetingType >= 0 && (int)meetingType <= 1)
                    {
                        break;
                    }
                    Console.WriteLine("Please select one more time:");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            while (true);
            return meetingType;
        }
        public static DateTime ReadDate()
        {
            DateTime date;
            do
            {
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (true);
            return date;
        }
        public static DateTime ReadEndDate(DateTime startDate)
        {
            DateTime endDate;
            do
            {
                endDate = ReadDate();
                if (endDate >= startDate)
                {
                    return endDate;
                }
                Console.Write("The end date should be greater or equal to the start date!\n" +
                    "Please enter ending date again: ");
            }
            while (true);
        }
        public static void CreateNewMeeting()
        {
            var meeting = Meeting.Create();
            if (CheckMeetingExist(meeting.Name))
            {
                Console.WriteLine("Meeting already exist! Press any key.");
                Console.ReadLine();
                return;
            }
            var meetingList = GetMeetingList();
            if (meetingList is null)
            {
                meetingList = new List<Meeting>();
            }
            meetingList.Add(meeting);
            var streamWrite = new WriteToFile();
            streamWrite.WriteDataToFile(meetingList);
            Console.WriteLine("Meeting was added. Press any key.");
            Console.ReadLine();
        }
        public static bool CheckMeetingExist(string Name)
        {
            var meetingList = GetMeetingList();

            if (meetingList is not null && meetingList.FirstOrDefault(m => m.Name == Name) != null)
            {
                return true;
            }
            return false;
        }
        public static void DispalyMeetingList(List<Meeting> meetingList)
        {
            if (meetingList is not null && meetingList.Count > 0)
            {
                foreach (Meeting meeting in meetingList)
                {
                    Console.WriteLine(meeting);
                }
                Console.WriteLine("Press any key.");
            }
            else
            {
                Console.WriteLine("Meeting list is empty. Press any key.");
            }
            Console.ReadLine();
        }
        public static void DeleteMeeting(string Name)
        {
            if (CheckMeetingExist(Name))
            {
                var meetingList = GetMeetingList();
                var meeting = meetingList.FirstOrDefault(m => m.Name == Name);
                if (meeting.ResponsiblePerson.Name == Login.user.Name &&
                    meeting.ResponsiblePerson.Surname == Login.user.Surname)
                { 
                    meetingList.Remove(meeting);
                    var streamWrite = new WriteToFile();
                    streamWrite.WriteDataToFile(meetingList);
                    Console.WriteLine("Meeting was deleted. Press any key.");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine("You can't delete other users meetings! Press any key.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("There is no such meeting! Press any key.");
            Console.ReadLine();
        }
        public static string ReadName()
        {
            var PersonName = "";
            Console.Write("Please enter persons name: ");
            do
            {
                try
                {
                    PersonName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (PersonName.Length > 0)
                {
                    return PersonName;
                }
                Console.Write("You have to enter persons name: ");
            }
            while (true);
        }
        public static string ReadSurname()
        {
            var PersonSurname = "";
            Console.Write("Please enter persons surname: ");
            do
            {
                try
                {
                    PersonSurname = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (PersonSurname.Length > 0)
                {
                    return PersonSurname;
                }
                Console.Write("You have to enter persons surname: ");
            }
            while (true);
        }
        public static string ReadMeetingName()
        {
            var meetingName = "";
            do
            {
                try
                {
                    meetingName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (meetingName.Length > 0)
                {
                    return meetingName;
                }
                Console.Write("You have to enter meeting name: ");
            }
            while (true);
        }
        public static string ReadMeetingDescription()
        {
            var meetingDescription = "";
            do
            {
                try
                {
                    meetingDescription = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (meetingDescription.Length > 0)
                {
                    return meetingDescription;
                }
                Console.Write("You have to enter meeting description: ");
            }
            while (true);
        }
        public static List<Meeting> GetMeetingList()
        {
            return new ReadFile().GetFileData();
        }
        public static Meeting SelectTheMeeting(string meetingName)
        {
            return GetMeetingList().FirstOrDefault(m => m.Name == meetingName);
        }
        public static void AddPersonToParticipantsList()
        {
            Console.Write("Please, select the meeting for replenishment: ");
            var meetingName = ReadMeetingName();
            if (CheckMeetingExist(meetingName))
            {
                var meetingList = new ReadFile().GetFileData();
                var meeting = GetMeetingList().FirstOrDefault(m => m.Name == meetingName);
                var person = new Person(ReadName(), ReadSurname());
                if(CheckPersonExist(meeting, person))
                {
                    Console.WriteLine("The person is already on the participants list! Press any key.");
                    Console.ReadLine();
                    return;
                }
                meeting.Participants.Add(person);
                meetingList.Remove(meetingList.FirstOrDefault(m => m.Name == meetingName));
                meetingList.Add(meeting);
                var streamWrite = new WriteToFile();
                streamWrite.WriteDataToFile(meetingList);

                Console.WriteLine("The person is added. Press any key.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("There is no such meeting! Press any key.");
            Console.ReadLine();
        }
        public static void DeletePersonFromParticipantsList()
        {
            Console.Write("Please, select the meeting for removing: ");
            var meetingName = ReadMeetingName();
            if (CheckMeetingExist(meetingName))
            {
                var meetingList = new ReadFile().GetFileData();
                var meeting = GetMeetingList().FirstOrDefault(m => m.Name == meetingName);
                var person = new Person(ReadName(), ReadSurname());
                if (!CheckPersonExist(meeting, person))
                {
                    Console.WriteLine("There is no such person on the participants list! Press any key.");
                    Console.ReadLine();
                    return;
                }
                if (meeting.ResponsiblePerson.Name == person.Name &&
                    meeting.ResponsiblePerson.Surname == person.Surname)
                {
                    Console.WriteLine("You can't remove the organizer! Press any key.");
                    Console.ReadLine();
                    return;
                }
                meeting.Participants.Remove(meeting.Participants.FirstOrDefault(p => p.Name == person.Name && p.Surname == person.Surname));
                meetingList.Remove(meetingList.FirstOrDefault(m => m.Name == meetingName));
                meetingList.Add(meeting);
                var streamWrite = new WriteToFile();
                streamWrite.WriteDataToFile(meetingList);

                Console.WriteLine("The person is delete. Press any key.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("There is no such meeting! Press any key.");
            Console.ReadLine();
        }
        public static bool CheckPersonExist(Meeting meeting, Person person)
        {
            if(meeting.Participants.FirstOrDefault(p => p.Name == person.Name && p.Surname == person.Surname) != null)
            {
                return true;
            }
            return false;
        }
    }
}
