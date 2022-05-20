using MeetingsApp.Model;
using Newtonsoft.Json;

namespace MeetingsApp.Services
{
    internal class WriteToFile
    {
        private readonly StreamWriter _streamWriter;
        private readonly string _path = @"Meetings.json";

        public WriteToFile()
        {
            try
            {
                if (!File.Exists(_path))
                {
                    File.Create(_path);
                }
                _streamWriter = new StreamWriter(_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WriteDataToFile(List<Meeting> meetingList)
        {
            _streamWriter.WriteLine(JsonConvert.SerializeObject(meetingList));
            CloseStream();
        }
        public void CloseStream()
        {
            _streamWriter.Close();
        }
    }
}
