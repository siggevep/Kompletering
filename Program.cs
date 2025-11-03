using System.Reflection.Metadata;
using app;




List<Room> rooms = new List<Room>();
List<User> users = new List<User>();
User? active_user = null;
bool running = true;

rooms.Add(new("1", "10", RoomStatus.Avaible));
rooms.Add(new("2", "10", RoomStatus.Cleaning));
rooms.Add(new("3", "10", RoomStatus.Maintence));
rooms.Add(new("4", "10",RoomStatus.Avaible));
rooms.Add(new("5", "10",RoomStatus.Avaible));
rooms.Add(new("6", "10",RoomStatus.Cleaning));
rooms.Add(new("7", "10",RoomStatus.Occupied));
rooms.Add(new("8", "10", RoomStatus.Avaible));
rooms.Add(new("9", "10", RoomStatus.Occupied));
rooms.Add(new("10", "10",RoomStatus.Cleaning));


users.Add(new("sigge", "kebab"));
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
    if (active_user == null) // ser om du är inloggad
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



        Console.WriteLine("hello here is your menu");
        Console.WriteLine("Look at the rooms with guests");
        Console.ReadLine();

        
    }

}



