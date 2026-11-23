namespace BlazorApp31.Models;

public class Appointment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PetId { get; set; }

    public int DoctorId { get; set; }

    public string Service { get; set; } = "";

    public DateTime DateTime { get; set; }

    public string Status { get; set; } = "Новая";

    public string Comment { get; set; } = "";
}