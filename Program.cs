using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using app;




List<Room> rooms = new List<Room>();
List<User> users = new List<User>();
User? active_user = null;
bool running = true;

rooms.Add(new("1", "kebab", RoomStatus.Avaible));
rooms.Add(new("2", "jon", RoomStatus.Cleaning));
rooms.Add(new("3", "ken", RoomStatus.Maintence));
rooms.Add(new("4", "lit",RoomStatus.Avaible));
rooms.Add(new("5", "stefan",RoomStatus.Avaible));
rooms.Add(new("6", "linus",RoomStatus.Cleaning));
rooms.Add(new("7", "arben",RoomStatus.Occupied));
rooms.Add(new("8", "lukas", RoomStatus.Avaible));
rooms.Add(new("9", "felix", RoomStatus.Occupied));
rooms.Add(new("10", "nisse",RoomStatus.Cleaning));


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
        Console.WriteLine("1.Look at the rooms with guests");
        Console.WriteLine("2. Look at the rooms with no guests");
        Console.WriteLine("3. Book a guest in a Avible room");
        Console.WriteLine("4. Mark a room temporarly not avilable");
        Console.WriteLine("5. Check out a guest");
        string choise = Console.ReadLine();
        switch (choise)
        {

            case "1":
                foreach (Room room in rooms)

                {
                    if (room.Status == RoomStatus.Avaible)
                        Console.WriteLine(room.Status);
                    System.Console.WriteLine(room.Roomnummer + "room nummber");
                   
                    System.Console.WriteLine("------------");

                }


                break;

            case "2":
                foreach (Room room in rooms)

                {
                    if (room.Status != RoomStatus.Avaible)
                    {


                        Console.WriteLine(room.Status);
                         System.Console.WriteLine(room.User + " is living here");
                        System.Console.WriteLine(room.Roomnummer + "room nummber");
                        System.Console.WriteLine("------------");
                    }
                }



                break;

            case "3":

                foreach (Room room in rooms)

                {
                    if (room.Status == RoomStatus.Occupied)
                    {


                        Console.WriteLine(room.Status);
                        System.Console.WriteLine(room.Roomnummer + "room nummber");
                        System.Console.WriteLine("------------");
                    }






                }
                System.Console.WriteLine("What number are you choosing");
                string number = Console.ReadLine()!;
                Console.Clear();
                System.Console.WriteLine("Choose a name for the guest room");
                string name = Console.ReadLine()!;

              foreach (Room room in rooms)
                {
                    if (room.Roomnummer == number)
                    {

                        room.Status = RoomStatus.Occupied;
                        room.User = name;

                    }
                    
                }

                break;


        }

    }
}



