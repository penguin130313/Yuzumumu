using BlazorApp31.Data;
using BlazorApp31.Models;

namespace BlazorApp31.Services;

public class AuthService
{
    private readonly YuzumumuDb _db;

    public User? CurrentUser { get; private set; }

    public bool IsAdmin { get; private set; }

    public string Error { get; private set; } = "";

    public AuthService(YuzumumuDb db)
    {
        _db = db;
    }
    
//регистрация нового пользователя
    public bool Register(
        string login,
        string password,
        string fullName,
        string phone,
        string email)
    {
        Error = "";
        

        if (login.Length < 6)
        {
            Error = "Логин должен содержать минимум 6 символов.";
            return false;
        }

        if (password.Length < 8)
        {
            Error = "Пароль должен содержать минимум 8 символов.";
            return false;
        }

        if (_db.Users.Any(u => u.Login == login))
        {
            Error = "Этот логин уже занят.";
            return false;
        }
        //создание нового пользователя и сохранение его в базе данных
        var user = new User
        {
            Login = login,
            Password = password,
            FullName = fullName,
            Phone = phone,
            Email = email
        };

        _db.Users.Add(user);
        _db.SaveChanges();

        return true;
    }
//проверка входа
    public bool Login(string login, string password)
    {
        Error = "";

        if (login == "Admin26" && password == "Demo20")
        {
            IsAdmin = true;
            CurrentUser = null;
            return true;
        }
//успешный вход в аккаунт и выход из системы
        var user = _db.Users.FirstOrDefault(u =>
            u.Login == login && u.Password == password);

        if (user == null)
        {
            Error = "Неверный логин или пароль.";
            return false;
        }

        CurrentUser = user;
        IsAdmin = false;

        return true;
    }

    public void Logout()
    {
        CurrentUser = null;
        IsAdmin = false;
        Error = "";
    }
}