namespace app;

class User
{

    public string name;

    string password;

    public User(string Name, string Password)
    {
        name = Name;
        password = Password;


    }

public bool TryLogin(string Name, string Password)
    {
        return Name == name && Password == password;

    }

}