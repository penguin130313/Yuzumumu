using BlazorApp31.Components;
using Microsoft.EntityFrameworkCore;
using BlazorApp31.Data;
using BlazorApp31.Models;
using BlazorApp31.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<YuzumumuDb>(options =>
    options.UseSqlite("Data Source=Yuzumumu.db"));
//Создай сервис и используй его в рамках текущего пользовательского подключения
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ClinicService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<YuzumumuDb>();

    db.Database.EnsureCreated();

    if (!db.Doctors.Any())
    {
        db.Doctors.AddRange(
            new Doctor
            {
                Name = "Владислава Беляева",
                Specialty = "Терапевт",
                Description = "Общий осмотр и консультации"
            },
            new Doctor
            {
                Name = "Герман Марков",
                Specialty = "Хирург",
                Description = "Хирургия животных"
            },
            new Doctor
            {
                Name = "Арина Соколова",
                Specialty = "Диагност",
                Description = "УЗИ и диагностика"
            }
        );

        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

