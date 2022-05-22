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
            Console.Clear();
            Controle.Title();
            Console.Write("Please, enter username: ");
            var userName = Service.ReadString();
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
            var password = Service.ReadString();
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
            Console.Write("Please enter your Name: ");
            var personName = Service.ReadString();
            Console.Write("Please enter your Surname: ");
            var personSurname = Service.ReadString();
            Console.Write("Please enter your password: ");
            var password = Service.ReadString();
            
            return new User() { UserName = userName, person = new Person(personName, personSurname), Password = password };
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
