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
                    "\n6 - Filter meetings by description" +
                    "\n7 - Filter meetings by responsible person" +
                    "\n8 - Filter meetings by category" +
                    "\n9 - Filter meetings by type" +
                    "\n10 - Filter meetings by dates" +
                    "\n11 - Filter meetings by the number of attendees" +
                    "\n0 - to exit" +
                    "\n-1 - logout");
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
                            AddPersonToParticipantsList();
                            break;
                        case 4:
                            DeletePersonToParticipantsList();
                            break;
                        case 5:
                            Service.DispalyMeetingList(Service.GetMeetingList());
                            break;
                        case 6:
                            Service.FilterByDescription();
                            break;
                        case 7:
                            Service.FilterByOrganizer();
                            break;
                        case 8:
                            Service.FilterByCategory();
                            break;
                        case 9:
                            Service.FilterByType();
                            break;
                        case 10:
                            Service.FilterByDate();
                            break;
                        case 11:
                            FilterByTheNumberOfAttendees();
                            break;
                        case -1:
                            Login.user = null;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (choice != 0 && choice != -1);
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
        public static void AddPersonToParticipantsList()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please select what do you want to do:" +
                    "\n1 - Add person to the list of participants" +
                    "\n2 - meetings list" +
                    "\n0 - to exit");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Service.AddPersonToParticipantsList();
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
        public static void DeletePersonToParticipantsList()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please select what do you want to do:" +
                    "\n1 - Delete person from the participants list" +
                    "\n2 - meetings list" +
                    "\n0 - to exit");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Service.DeletePersonFromParticipantsList();
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
        public static void FilterByTheNumberOfAttendees()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                int participantsNumber;
                Console.WriteLine("Please select how you want to filter:" +
                    "\n1 - less than" +
                    "\n2 - equal to" +
                    "\n3 - greiter than" +
                    "\n0 - to exit");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Please, enter participants number: ");
                            participantsNumber = Service.ReadInteger();
                            Service.DispalyMeetingList(Service.GetMeetingList()
                                .Where(m => m.Participants.Count() < participantsNumber)
                                .ToList());
                            break;
                        case 2:
                            Console.Write("Please, enter participants number: ");
                            participantsNumber = Service.ReadInteger();
                            Service.DispalyMeetingList(Service.GetMeetingList()
                                .Where(m => m.Participants.Count() == participantsNumber)
                                .ToList());
                            break;
                        case 3:
                            Console.Write("Please, enter participants number: ");
                            participantsNumber = Service.ReadInteger();
                            Service.DispalyMeetingList(Service.GetMeetingList()
                                .Where(m => m.Participants.Count() > participantsNumber)
                                .ToList());
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
