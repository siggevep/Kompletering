namespace app;

public class Room
{


    public string Roomnummer;

    public string User;

    public RoomStatus Status;

    public Room(string roomnummer, string user, RoomStatus status)
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