using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Teachers.Application;
using MoricApps.EPlatform.Teachers.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
        corsbuilder =>
        {
            corsbuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddDbContext<TeachersDbContext>(
    DbContextOptions => DbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:TeachersConnectionString"]));
builder.Services.AddEmailService();
builder.Services.AddTeacherRepository();
builder.Services.AddTeacherService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeaders");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
