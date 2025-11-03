using System.Reflection.Metadata;
using app;


List<Room> rooms = new List<Room>();
List<User> users = new List<User>();
User? active_user = null;
bool running = true;
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
while (running)
{
    if (active_user == null)
    {
        Console.WriteLine("Hello you need to login first login?");

        Console.WriteLine("Username:");
        string username = Console.ReadLine()!;
        Console.Clear();

        Console.WriteLine("Password");
        string password = Console.ReadLine()!;
        foreach (User user in users)
            if (user.TryLogin(username, password))
            {
                active_user = user;

            }
    }
        
  if (active_user != null)
    {



        Console.WriteLine("hello");


        
    }

}



