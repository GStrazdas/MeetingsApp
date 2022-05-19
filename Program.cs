﻿/********************************
 *                              *
 *      .NET Developer Task     *
 *      Gediminas Strazdas      *
 *      2022-05-17              *
 *                              *
 * ******************************/

using MeetingsApp;
using static MeetingsApp.DataTypes;

bool run = true;
string data = "";

do
{
    Console.Clear();
    Console.WriteLine("Please select what do you want to do:" +
        "\n1 - create a new meeting" +
        "\n2 - delete a meeting" +
        "\n3 - add person to the meeting" +
        "\n4 - remove person from the meeting" +
        "\n5 - meetings list" +
        "\n6 - try method" +
        "\n7 - read from file" +
        "\n8 - write to file" +
        "\n0 - to exit");
    try
    {
        var choice = int.Parse(Console.ReadLine());
        switch(choice)
        {
            case 1:
                Service.CreateNewMeeting();
                break;
            case 2:
                Console.WriteLine("delete a meeting");
                break;
            case 3:
                Console.WriteLine("add person to the meeting");
                break;
            case 4:
                Console.WriteLine("remove person from the meeting");
                break;
            case 5:
                Console.WriteLine("meetings list");
                break;
            case 6:
                Console.WriteLine("Create meeting");
                var meeting = Meeting.Create();
                break;
            case 7:
                Console.WriteLine("Open file");
                var streamRead = new ReadFile();
                data = streamRead.GetFileData();
                Console.WriteLine($"Failo turinys:\n{data}");
                streamRead.CloseStream();
                Console.ReadLine();
                break;
            case 8:
                Console.WriteLine($"Write to file:\n{data}");
                var streamWrite = new WriteToFile();
                streamWrite.WriteDataToFile(data);
                streamWrite.CloseStream();
                Console.ReadLine();
                break;
            case 0:
                run = false;
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
while(run);

Console.WriteLine("Finished");