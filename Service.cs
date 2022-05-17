using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeetingsApp.DataTypes;

namespace MeetingsApp
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
                    if((int)category >= 0 && (int)category <= 3)
                    {
                        break;
                    }
                    Console.WriteLine("Please select one more time:");
                    continue;
                }
                catch(Exception ex)
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
        public static DateOnly ReadDate()
        {
            DateOnly date;
            do
            {
                try
                {
                    date = DateOnly.Parse(Console.ReadLine());
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } 
            }
            while (true);
            return date;
        }
    }
}
