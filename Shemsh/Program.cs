using System.Text.Json.Serialization;
using Application.Services;
using Domain.IRepositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Scan(scan => scan
    .FromAssemblyOf<EmployeeService>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<EmployeeRepository>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
    .AsImplementedInterfaces()
    .WithScopedLifetime());


builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
});


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
