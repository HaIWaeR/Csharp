using System;

public class User
{
    public static int Count { get; protected set; } = 0; 

    private string _name;
    private readonly string _login;
    private string _password;
    private readonly int _grade;

    public User(string name, string login, string password, int grade)
    {
        _name = name;
        _login = login;
        _password = password;
        _grade = grade;
        Count++;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Login
    {
        get => _login;
        set => Console.WriteLine("Невозможно изменить логин!");
    }

    // ебучий патерн
    public string Password
    {
        set => _password = value;
        get => "********";
    }

    public int Grade
    {
        get
        {
            Console.WriteLine("Неизвестное свойство grade");
            return 0;
        }
        set => Console.WriteLine("Неизвестное свойство grade");
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {_name}, Login: {_login}");
    }

    public static bool operator <(User a, User b) => a._grade < b._grade;
    public static bool operator >(User a, User b) => a._grade > b._grade;
    public static bool operator <=(User a, User b) => a._grade <= b._grade;
    public static bool operator >=(User a, User b) => a._grade >= b._grade;
    public static bool operator ==(User a, User b) => a._grade == b._grade;
    public static bool operator !=(User a, User b) => a._grade != b._grade;

    public override bool Equals(object obj) => obj is User user && this == user;
    public override int GetHashCode() => _grade.GetHashCode();
}

public class SuperUser : User
{
    public static new int Count { get; private set; } = 0;

    private string _role;

    public SuperUser(string name, string login, string password, string role, int grade)
        : base(name, login, password, grade)
    {
        _role = role;
        Count++;
        User.Count--; 
    }

    public string Role
    {
        get => _role;
        set => _role = value;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}, Login: {Login}, Role: {_role}");
    }
}

class Program
{
    static void ColorLine()
    {
        Console.WriteLine();
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('*', 120));
        Console.ForegroundColor = originalColor;
    }
    static void Main()
    {
        ColorLine();
        var user1 = new User("Paul McCartney", "paul", "1234", 3);
        var user2 = new User("George Harrison", "george", "5678", 2);
        var user3 = new User("Richard Starkey", "ringo", "8523", 3);
        var admin = new SuperUser("John Lennon", "john", "0000", "admin", 5);

        user1.ShowInfo();
        admin.ShowInfo();
        ColorLine();

        Console.WriteLine($"Всего обычных пользователей: {User.Count}");
        Console.WriteLine($"Всего супер-пользователей: {SuperUser.Count}");
        ColorLine();

        Console.WriteLine($"Пользователь: {user1} < {user2} ({(user1 < user2)})");
        Console.WriteLine($"Пользователь: {admin} > {user3} ({(admin > user3)})");
        Console.WriteLine($"Пользователь: {user1} = {user3} ({(user1 == user3)})");
        ColorLine();

        user3.Name = "Ringo Starr";
        user1.Password = "Pa$$w0rd";
        
        Console.WriteLine(user3.Name);
        Console.WriteLine(user2.Password);
        Console.WriteLine(user2.Login);

        user2.Login = "geo";

        var grade = user1.Grade;
        admin.Grade = 10;
        ColorLine();
    }
}