using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using app;




List<Room> rooms = new List<Room>();
List<User> users = new List<User>();
User? active_user = null;
bool running = true;

//lägger till rum då det inte står att det ska finns hur många rum som hälst


if (File.Exists("Room.txt"))//denna funktionen läser in alla raderna och sedan lägger till dem i listan
{
    string[] lines1 = File.ReadAllLines("Room.txt");//fixar en arayy för listor som är rader

    foreach (string line in lines1)
    {
        string[] data = line.Split(","); //splitar en rad into sequtioner
        string number = data[0];
        string user1 = data[1];
        string statusText = data[2];

        if (Enum.TryParse(statusText, out RoomStatus status)) //parsar data 2(eller ja det efter andra , )
        {
            rooms.Add(new Room(number, user1, status)); //lägger till dem
        }
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
        Console.WriteLine("6. vMake a room in maintence Avible");
            string choise = Console.ReadLine()!;
        switch (choise)
        {

            case "1":
                foreach (Room room in rooms)

                {
                    if (room.Status == RoomStatus.Occupied)
                    { //om rum är occupied så händer detta
                        Console.WriteLine(room.Status);
                        System.Console.WriteLine(room.User + " is living here");
                        System.Console.WriteLine(room.Roomnummer + "room nummber");

                        System.Console.WriteLine("------------");
                    }

                }

                Console.ReadLine();
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

                foreach (Room roms in rooms)
                {

                    if (roms.Roomnummer == number)//uppdaterar rumme i rooms listan 
                    {

                        roms.User = name;
                        roms.Status = RoomStatus.Occupied;
                        break;


                    }
                }
                List<string> updatedLines = new List<string>();//för att kunna hitta den speficifa raden och ändra den

                foreach (var room in rooms) //säger till att varje rad i txt filen sparas och sedan läggs i stringen line och den läggs till i updated lines listan, vilket gör så att när man senare skriver in updated lines i txt filen sparas all den gamla infon förutom den som har ändrats på 
                {
                    string line = $"{room.Roomnummer},{room.User},{room.Status}";
                    updatedLines.Add(line);
                }

                File.WriteAllLines("Room.txt", updatedLines);
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

                foreach (Room room in rooms)//loopar alla rummen
                {

                    if (room.Roomnummer == disable)//kollar så det är rätt
                    {
                        room.Status = RoomStatus.Maintence;// ändrar statusen
                        room.User = ""; //ändrar usern
                    }
                }
                List<string> updatedLiness = new List<string>();//denna tar imprencip bort alla raderna och sedan skriver tillbaka dem och den nya raden är uppdaterad(med hjälp av raderna inder)

                foreach (var room in rooms) //loppar igenom alla i listan
                {
                    string line = $"{room.Roomnummer},{room.User},{room.Status}";//sparar alla raderna
                    updatedLiness.Add(line);
                }

                File.WriteAllLines("Room.txt", updatedLiness);//skriver över det gamla och lägger till alla nya rader


                Console.Clear();
                break;


            case "5":

                foreach (Room room in rooms) //kollar alla rum som är Occupied, du skriver sedan vilket namn och sedan ändrar namnet till tomt och ändrar statuset till Avialible
                {
                    if (room.Status == RoomStatus.Occupied)//käckar om rummet är Occupied eller inte
                    {
                        System.Console.WriteLine(room.User + " this is the person living here");
                        System.Console.WriteLine(room.Roomnummer + " this is the room nummer");


                    }


                }

                System.Console.WriteLine("what Guest do you want to CHeckout out");
                string Check = Console.ReadLine()!;
                foreach (Room room in rooms)//loopar alla rummen
                {

                    if (room.User == Check)//kollar så att det är rätt user
                    {
                        room.User = " ";//ändrar alla namnen
                        room.Status = RoomStatus.Avaible;//ändrar statusen
                        break;
                    }
                }
                List<string> updatedLine = new List<string>();//denna tar imprencip bort alla raderna och sedan skriver tillbaka dem och den nya raden är uppdaterad

                foreach (var room in rooms) //-,,-
                {
                    string line = $"{room.Roomnummer},{room.User},{room.Status}";
                    updatedLine.Add(line);
                }

                File.WriteAllLines("Room.txt", updatedLine);

                break;
            case "6":

                foreach (Room room in rooms)//loopar alla rummen
                {

                    if (room.Status == RoomStatus.Maintence)//kollar så att det är rätt user
                    {

                        Console.WriteLine(room.Status);
                        System.Console.WriteLine(room.Roomnummer + "room nummber");
                        System.Console.WriteLine("------------");
                    }



                }
                Console.WriteLine("What room do you want to make avible");
     string CHange = Console.ReadLine()!;
                foreach (Room room in rooms)
                {
                    
                  if(room.Roomnummer == CHange)
                    {
                        room.Status = RoomStatus.Avaible;


                    }


                }
                Console.WriteLine("Room number " + CHange + "is avible");
                  List<string> updatedLine1 = new List<string>();//denna tar imprencip bort alla raderna och sedan skriver tillbaka dem och den nya raden är uppdaterad

                foreach (var room in rooms) //-,,-
                {
                    string line = $"{room.Roomnummer},{room.User},{room.Status}";
                    updatedLine1.Add(line);
                }

                File.WriteAllLines("Room.txt", updatedLine1);
               
               

                break;
        }
            

        }
    }



