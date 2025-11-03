using System.Reflection.Metadata;
using app;


List<Room> rooms = new List<Room>();
List<User> users = new List<User>();


Console.WriteLine("Hello, World!");

if (File.Exists("Users.txt"))
{

    string[] lines = File.ReadAllLines("Users.txt");
    foreach (string line in lines)
    {

        string[] data = line.Split(",");
        users.Add(new(data[0], data[1]));
    }
}

