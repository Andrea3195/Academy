using API_torneo_Mario.Models;
using API_torneo_Mario.Repos;
using API_torneo_Mario.Services;
using Microsoft.EntityFrameworkCore;

namespace Api_MarioKart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Context>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<PersonaggioRepo>();
            builder.Services.AddScoped<SquadraRepo>();
            builder.Services.AddScoped<PersonaggioService>();
            //builder.Services.AddScoped<SquadraService>();
            var app = builder.Build();

            app.UseCors(builder =>
            builder
            .WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}