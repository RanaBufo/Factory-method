using Microsoft.EntityFrameworkCore;
using MilaLaba;

var builder = WebApplication.CreateBuilder(args);


// BD
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    // Создаем строку подключения к базе данных MySQL
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Устанавливаем провайдер данных как MySQL
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
