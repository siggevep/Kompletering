namespace app;

class Room
{


    int Roomnummer;

    string User;

    public RoomStatus Status;

    public Room(int roomnummer, string user,RoomStatus status)
    {
        Roomnummer = roomnummer;
        User = user;
        Status = status;
    }

}

public enum RoomStatus
{

    Avaible,

    Occupied,

    Cleaning,

    Maintence,

}