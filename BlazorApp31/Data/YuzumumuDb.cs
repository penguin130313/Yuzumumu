using Microsoft.EntityFrameworkCore;
using BlazorApp31.Models;

namespace BlazorApp31.Data;

public class YuzumumuDb : DbContext
{
    public YuzumumuDb(DbContextOptions<YuzumumuDb> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Pet> Pets => Set<Pet>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<Review> Reviews => Set<Review>();
}