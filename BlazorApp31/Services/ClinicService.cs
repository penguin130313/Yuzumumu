
using BlazorApp31.Data;
using BlazorApp31.Models;

namespace BlazorApp31.Services;

public class ClinicService
{
    private readonly YuzumumuDb _db;

    public ClinicService(YuzumumuDb db)
    {
        _db = db;
    }

    // Список врачей
    public List<Doctor> Doctors => _db.Doctors.ToList();

    // Питомцы конкретного пользователя
    public List<Pet> PetsFor(int userId)
    {
        return _db.Pets.Where(p => p.UserId == userId).ToList();
    }

    // Записи конкретного пользователя
    public List<Appointment> AppointmentsFor(int userId)
    {
        return _db.Appointments
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.DateTime)
            .ToList();
    }

    // Все записи для администратора
    public List<Appointment> AllAppointments =>
        _db.Appointments.OrderBy(a => a.DateTime).ToList();

    // Найти врача
    public Doctor? DoctorById(int id)
    {
        return _db.Doctors.Find(id);
    }

    // Найти питомца
    public Pet? PetById(int id)
    {
        return _db.Pets.Find(id);
    }

    // Найти пользователя
    public User? UserById(int id)
    {
        return _db.Users.Find(id);
    }

    // Добавить питомца
    public void AddPet(Pet pet)
    {
        _db.Pets.Add(pet);
        _db.SaveChanges();
    }

    // Добавить запись на приём
    public void AddAppointment(Appointment appointment)
    {
        appointment.Status = "Новая";
        _db.Appointments.Add(appointment);
        _db.SaveChanges();
    }

    // Изменить статус записи
    public void SetStatus(int id, string status)
    {
        var appointment = _db.Appointments.Find(id);

        if (appointment != null)
        {
            appointment.Status = status;
            _db.SaveChanges();
        }
    }

    // Добавить отзыв
    public void AddReview(Review review)
    {
        _db.Reviews.Add(review);
        _db.SaveChanges();
    }

    // Список отзывов
    public List<Review> Reviews =>
        _db.Reviews.OrderByDescending(r => r.CreatedAt).ToList();
}
