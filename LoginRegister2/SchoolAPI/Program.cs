using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Context;
using SchoolAPI.Data.Entity;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SchoolDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped < ISchoolServices<Fakülte>,SchoolServices<Fakülte>>();
builder.Services.AddScoped<ISchoolServices<Bölüm>,SchoolServices<Bölüm>>(); 
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
