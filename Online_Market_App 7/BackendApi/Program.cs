using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MarketContext>(
                options => options.UseSqlServer("Server=DESKTOP-2LBF1EI;Database=Market;Integrated Security=true;"));

            builder.Services.AddScoped<Domain.Interfaces.IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

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
        }
    }
}