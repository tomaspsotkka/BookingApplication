using System.Text.Json.Serialization;
using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using BusinessLogic.Util;
using EfcRepositories;
using RepositoryContracts;
using AppContext = EfcRepositories.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IResourceRepository, EfcResourceRepository>();
builder.Services.AddScoped<IBookingRepository, EfcBookingRepository>();
builder.Services.AddDbContext<AppContext>();
builder.Services.AddScoped<IResourceLogic, ResourceLogic>();
builder.Services.AddScoped<IBookingLogic, BookingLogic>();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();