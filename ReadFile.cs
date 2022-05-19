using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsApp
{
    internal class ReadFile
    {
        private readonly StreamReader _streamRead;
        private readonly string _path = @"C:\Users\gedst\source\repos\MeetingsApp\Repos\Meetings.json";

        public ReadFile()
        {
            try
            {
                _streamRead = new StreamReader(_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string GetFileData()
        {
            return _streamRead.ReadToEnd();
        }
        public void CloseStream()
        {
            _streamRead.Close();
        }
    }
}
