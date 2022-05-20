using MeetingsApp.Model;
using Newtonsoft.Json;

namespace MeetingsApp.Services
{
    internal class ReadFile
    {
        private readonly StreamReader _streamRead;
        private readonly string _path = @"Meetings.json";

        public ReadFile()
        {
            try
            {
                if (!File.Exists(_path))
                {
                    using(File.Create(_path));
                }
                _streamRead = new StreamReader(_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Meeting> GetFileData()
        {
            var meetingList = JsonConvert.DeserializeObject<List<Meeting>>(_streamRead.ReadToEnd());
            CloseStream();
            return meetingList;
        }
        public void CloseStream()
        {
            _streamRead.Close();
        }
    }
}
