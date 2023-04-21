using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GaleriesInfinieAPI.Data;
using GaleriesInfinieAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GaleriesInfinieAPIContext>(options =>
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("GaleriesInfinieAPIContext") ?? throw new InvalidOperationException("Connection string 'GaleriesInfinieAPIContext' not found."));
    options.UseLazyLoadingProxies();   
}) ;
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<GaleriesInfinieAPIContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = "http://localhost:4200",
        ValidIssuer = "https://localhost:7183",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Cette Phrase est tellement longue quelle va empêcher les hackers de passer"))

    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
