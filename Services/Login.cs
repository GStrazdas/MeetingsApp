using MeetingsApp.Model;
using Newtonsoft.Json;

namespace MeetingsApp.Services
{
    internal class Login
    {
        private readonly string _path = @"Users.json";
        private StreamReader streamRead;
        private StreamWriter streamWriter;
        public static Person user;

        public void CheckUser()
        {
            Console.Write("Please, enter user name: ");
            var userName = ReadUserName();
            CheckAndCreateUserFile();
            if (CheckUserExist(userName))
            {
                CheckPassword(userName);
                return;
            }
            var newUser = CreateNewUser(userName);
            AddNewUser(newUser);
            user = newUser.person;
        }
        private void CheckPassword(string userName)
        {
            Console.Write("Please, enter your password: ");
            var password = ReadPassword();
            var verifiableUser = GetUserList().FirstOrDefault(u => u.UserName == userName);
            if (verifiableUser.Password == password)
            {
                user = verifiableUser.person;
                return;
            }
            Console.WriteLine("Wrong username or password!");
            Console.ReadLine();
        }
        private bool CheckUserExist(string userName)
        {
            if(GetUserList().FirstOrDefault(u => u.UserName == userName) != null)
            {
                return true;
            }
            return false;
        }
        private void CheckAndCreateUserFile()
        {
            if (!File.Exists(_path))
            {
                using (File.Create(_path));
            }
        }
        private List<User> GetUserList()
        {
            streamRead = new StreamReader(_path);
            var userList = JsonConvert.DeserializeObject<List<User>>(streamRead.ReadToEnd());
            streamRead.Close();
            if(userList is null)
            {
                userList = new List<User>();
            }
            return userList;
        }
        private User CreateNewUser(string userName)
        {
            Console.WriteLine("This the first time you login.");
            Console.Write("\nPlease enter your Name: ");
            var personName = ReadName();
            Console.Write("\nPlease enter your Surname: ");
            var personSurname = ReadSurname();
            Console.Write("\nPlease enter your password: ");
            var password = ReadPassword();
            
            return new User() { UserName = userName, person = new Person(personName, personSurname), Password = password };
        }
        private string ReadName()
        {
            var PersonName = "";
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
                Console.Write("\nYou have to enter your name: ");
            }
            while (true);
        }
        private string ReadSurname()
        {
            var PersonSurname = "";
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
                Console.Write("\nYou have to enter your surname: ");
            }
            while (true);
        }
        private string ReadPassword()
        {
            var PersonPassword = "";
            do
            {
                try
                {
                    PersonPassword = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (PersonPassword.Length > 0)
                {
                    return PersonPassword;
                }
                Console.Write("\nYou have to enter your password: ");
            }
            while (true);
        }
        private string ReadUserName()
        {
            var UserName = "";
            do
            {
                try
                {
                    UserName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (UserName.Length > 0)
                {
                    return UserName;
                }
                Console.Write("\nYou have to enter your username: ");
            }
            while (true);
        }
        private void AddNewUser(User _user)
        {
            var userList = GetUserList();
            userList.Add(_user);
            CheckAndCreateUserFile();
            streamWriter = new StreamWriter(_path);
            streamWriter.WriteLine(JsonConvert.SerializeObject(userList));
            streamWriter.Close();
        }
    }
 }
