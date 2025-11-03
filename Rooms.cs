namespace app;

class Room
{


    public string Roomnummer;

    public string User;

    public RoomStatus Status;
    private string v1;
    private string v2;
    private string v3;

    public Room(string roomnummer, string user,RoomStatus status)
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