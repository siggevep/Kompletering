using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using app;




List<Room> rooms = new List<Room>();
List<User> users = new List<User>();
User? active_user = null;
bool running = true;

//lägger till rum då det inte står att det ska finns hur många rum som hälst


if (File.Exists("Room.txt"))
{
    string[] lines1 = File.ReadAllLines("Room.txt");

    foreach (string line in lines1)
    {
        string[] data = line.Split(",");
        string number = data[0];
        string user1 = data[1];
        string statusText = data[2];

        if (Enum.TryParse(statusText, ignoreCase: true, out RoomStatus status))
        {
            rooms.Add(new Room(number, user1, status));
        }
    }



    if (File.Exists("Users.txt")) //läser igenom alla users i Users.txt
    {

        string[] lines2 = File.ReadAllLines("Users.txt");
        foreach (string line in lines2)
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
            foreach (User user in users)// försöker lågga in
                if (user.TryLogin(username, password))
                {
                    active_user = user;

                }
        }

        if (active_user != null) //om du är inloggade så händer detta
        {


            Console.Clear();
            Console.WriteLine("hello here is your menu");
            Console.WriteLine("1.Look at the rooms with guests");
            Console.WriteLine("2. Look at the rooms with no guests");
            Console.WriteLine("3. Book a guest in a Avible room");
            Console.WriteLine("4. Mark a room temporarly not avilable");
            Console.WriteLine("5. Check out a guest");
            string choise = Console.ReadLine()!;
            switch (choise)
            {

                case "1":
                    foreach (Room room in rooms)

                    {
                        if (room.Status == RoomStatus.Occupied) //om rum är occupied så händer detta
                            Console.WriteLine(room.Status);
                        System.Console.WriteLine(room.User + " is living here");
                        System.Console.WriteLine(room.Roomnummer + "room nummber");

                        System.Console.WriteLine("------------");

                    }


                    break;

                case "2":
                    foreach (Room room in rooms)

                    {
                        if (room.Status != RoomStatus.Occupied) //om rum inte är occupied så händer detta 
                        {


                            Console.WriteLine(room.Status);
                            System.Console.WriteLine(room.Roomnummer + "room nummber");
                            System.Console.WriteLine("------------");
                           
                        }
                    }
 Console.ReadLine();


                    break;

                case "3":

                    foreach (Room room in rooms) // visar alla rum som är lediga

                    {
                        if (room.Status == RoomStatus.Avaible)
                        {


                            Console.WriteLine(room.Status);
                            System.Console.WriteLine(room.Roomnummer + "room nummber");
                            System.Console.WriteLine("------------");
                        }






                    }
                    // får dig att skrive rum nummer och namn och sedan ändrar det rummit till occupied och ändrar namnet till namnet du skrev
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





                case "4":


                    foreach (Room room in rooms) // skriver alla run för att tillfälidgt sätta ett room i maintence

                    {

                        Console.WriteLine(room.Status);
                        System.Console.WriteLine(room.Roomnummer + "room nummber");
                        System.Console.WriteLine("------------");

                    }
                    System.Console.WriteLine("What room do you want to tempoarly diasble");
                    string disable = Console.ReadLine()!;  // väljer rum nummer och sedan ändrar den till Maintence

                    foreach (Room room in rooms)
                    {

                        if (room.Roomnummer == disable)
                        {
                            room.Status = RoomStatus.Maintence;

                        }
                    }
                    Console.Clear();
                    break;


                case "5":

                    foreach (Room room in rooms) //kollar alla rum som är Occupied, du skriver sedan vilket namn och sedan ändrar namnet till tomt och ändrar statuset till Avialible
                    {
                        if (room.Status == RoomStatus.Occupied)
                        {
                            System.Console.WriteLine(room.User + " this is the person living here");
                            System.Console.WriteLine(room.Roomnummer + " this is the room nummer");


                        }


                    }

                    System.Console.WriteLine("what Guest do you want to CHeckout out");
                    string Check = Console.ReadLine()!;
                    foreach (Room room in rooms)
                    {

                        if (room.User == Check)
                        {
                            room.User = " ";
                            room.Status = RoomStatus.Avaible;

                        }
                    }

                    break;
            }

        }
    }
}


