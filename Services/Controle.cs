using MeetingsApp.Model;

namespace MeetingsApp.Services
{
    internal class Controle
    {
        public static int MainMenu()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please select what do you want to do:" +
                    "\n1 - create a new meeting" +
                    "\n2 - delete a meeting" +
                    "\n3 - add person to the meeting" +
                    "\n4 - remove person from the meeting" +
                    "\n5 - meetings list" +
                    "\n9 - logout" +
                    "\n0 - to exit");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Service.CreateNewMeeting();
                            break;
                        case 2:
                            DeleteMeeting();
                            break;
                        case 3:
                            Console.WriteLine("add person to the meeting");
                            break;
                        case 4:
                            Console.WriteLine("remove person from the meeting");
                            break;
                        case 5:
                            Service.DispalyMeetingList(Service.GetMeetingList());
                            break;
                        case 9:
                            Login.user = null;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (choice != 0 && choice != 9);
            return choice;
        }
        public static int LoginScreen()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please select what do you want to do:" +
                    "\n1 - login" +
                    "\n0 - to exit");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            new Login().CheckUser();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (Login.user is null && choice != 0);
            if(choice != 0)
            {
                choice = MainMenu();
            }
            return choice;
        }
        public static void Title()
        {
            Console.WriteLine("MeetingApp");
            Console.WriteLine($"{DateTime.Today}");
            if (Login.user is not null)
            {
                Console.WriteLine($"User: {Login.user}");
            }
         }
        public static void DeleteMeeting()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please select what do you want to do:" +
                    "\n1 - select meeting to delete" +
                    "\n2 - meetings list" +
                    "\n0 - to exit");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Please, select the meeting to delete: ");
                            Service.DeleteMeeting(Service.ReadMeetingName());
                            break;
                        case 2:
                            Service.DispalyMeetingList(Service.GetMeetingList());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (choice != 0);
        }
    }
}
