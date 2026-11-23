namespace BlazorApp31.Models;

public class Pet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = "";

    public string Kind { get; set; } = "";

    public string Breed { get; set; } = "";

    public int Age { get; set; }
}