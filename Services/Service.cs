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
                Console.WriteLine("The end date should be greater or equal to the start date!");
            }
            while (true);
        }
        public static void CreateNewMeeting()
        {
            var meeting = Meeting.Create();
            if (MeetingExist(meeting.Name))
            {
                Console.WriteLine("Meeting already exist... press any key");
                Console.ReadLine();
                return;
            }
            var meetingList = new ReadFile().GetFileData();
            meetingList.Add(meeting);
            var streamWrite = new WriteToFile();
            streamWrite.WriteDataToFile(meetingList);
            Console.WriteLine("Meeting was added. press any key");
            Console.ReadLine();
        }
        public static bool MeetingExist(string Name)
        {
            var meetingList = new ReadFile().GetFileData();
            if (meetingList.FirstOrDefault(m => m.Name == Name) != null)
            {
                return true;
            }
            return false;
        }
        public static void DispalyMeetingList(List<Meeting> meetingList)
        {
            foreach (Meeting meeting in meetingList)
            {
                Console.WriteLine(meeting);
            }
        }
        public static void DeleteMeeting(string Name)
        {
            var meetingList = new ReadFile().GetFileData();
            if (MeetingExist(Name))
            {
                meetingList.Remove(meetingList.FirstOrDefault(m => m.Name == Name));
                var streamWrite = new WriteToFile();
                streamWrite.WriteDataToFile(meetingList);
                Console.WriteLine("Meeting was deleted. press any key");
                Console.ReadLine();
            }
        }
    }
}
