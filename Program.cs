
using API_Practica.Context;
using API_Practica.Interfaces;
using API_Practica.Services;
using Microsoft.EntityFrameworkCore;

namespace API_Practica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*builder.Services.AddSqlServer<PersonaContext>
                (builder.Configuration.GetConnectionString("SqlServerConnection"));*/

            builder.Services.AddDbContext<PersonaContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("MySqlConnection"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))
                    ));

            builder.Services.AddDbContext<MascotaContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("MySqlConnection"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))
                    ));

            builder.Services.AddCors(options =>
            { options.AddPolicy("AllowFrontend", Policy =>
            { Policy.WithOrigins()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddScoped<IPersona, PersonaServices>();
            builder.Services.AddScoped<IMascota, MascotaServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //}

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swgger/v1/swagger.json", "Mi API v1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
