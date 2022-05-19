using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsApp
{
    internal class WriteToFile
    {
        private readonly StreamWriter _streamWriter;
        private readonly string _path = @"C:\Users\gedst\source\repos\MeetingsApp\Repos\Meetings.json";

        public WriteToFile()
        {
            try
            {
                _streamWriter = new StreamWriter(_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WriteDataToFile(string data)
        {
            _streamWriter.WriteLine(data);
        }
        public void CloseStream()
        {
            _streamWriter.Close();
        }
    }
}
