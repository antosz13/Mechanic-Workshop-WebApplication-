using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MechanicApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSerilog(
                    config =>
                        config
                            .MinimumLevel.Information()
                            .WriteTo.Console()
                            .WriteTo.File("log.txt"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
            }, ServiceLifetime.Singleton);

            builder.Services.AddSingleton<IClientService, ClientService>();
            builder.Services.AddSingleton<IJobService, JobService>();


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
