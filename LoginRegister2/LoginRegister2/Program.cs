

using LoginRegister2.DATA.Context;
using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Helpers.EmailSender;
using LoginRegister2.DATA.Helpers.JWT;
using LoginRegister2.DATA.Helpers.Validation;
using LoginRegister2.DATA.Interface;
using LoginRegister2.DATA.Model;
using LoginRegister2.DATA.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddIdentity<User, IdentityRole>(_ =>
{
    _.Password.RequiredLength = 5; //En az kaç karakterli olmasý gerektiðini belirtiyoruz.
    _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluðunu kaldýrýyoruz.
    _.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldýrýyoruz.
    _.Password.RequireUppercase = false; //Büyük harf zorunluluðunu kaldýrýyoruz.
    _.Password.RequireDigit = false; //0-9 arasý sayýsal karakter zorunluluðunu kaldýrýyoruz.)
})
    .AddEntityFrameworkStores<DBContext>()
    .AddUserValidator<UserValidatiton>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddAuthentication(options=>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (builder.Configuration["Token:SecurityKey"])),
            ClockSkew = TimeSpan.Zero 
        };

    }
 );

builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IAddressServices, AddressServices>();    
builder.Services.AddScoped<IJWT, JWT>();
builder.Services.AddScoped<IEmailServices,EMailServices>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
