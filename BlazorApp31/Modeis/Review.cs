namespace BlazorApp31.Models;

public class Review
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string UserName { get; set; } = "";

    public string Text { get; set; } = "";

    public int Rating { get; set; } = 5;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}