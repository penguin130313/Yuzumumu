namespace BlazorApp31.Models;

public class User
{
    public int Id { get; set; }

    public string Login { get; set; } = "";

    public string Password { get; set; } = "";

    public string FullName { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Email { get; set; } = "";
}