/********************************
 *                              *
 *      .NET Developer Task     *
 *      Gediminas Strazdas      *
 *      2022-05-17              *
 *                              *
 * ******************************/

using static MeetingsApp.DataTypes;

bool run = true;
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
        "\n0 - to exit");
    try
    {
        var choice = int.Parse(Console.ReadLine());
        switch(choice)
        {
            case 1:
                Console.WriteLine("create a new meeting");
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
                Console.WriteLine("Select category");
                SelectCategory();
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

void SelectCategory()
{
    Console.WriteLine("Please select meeting category:" +
                "\n0 - CodeMonkey" +
                "\n1 - Hub," +
                "\n2 - Short" +
                "\n3 - TeamBuilding):");
    Category category = (Category)int.Parse(Console.ReadLine());
    Console.WriteLine(category);
    Console.ReadLine();
}