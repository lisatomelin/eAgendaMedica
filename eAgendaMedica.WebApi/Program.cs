using eAgenda.WebApi.Config;
using eAgendaMedica.WebApi.Config;
using eAgendaMedica.WebApi.Config.AutomapperConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace NoteKeeper.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = false;
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
            });

            builder.Services.ConfigurarSerilog(builder.Logging);
            builder.Services.ConfigurarAutoMapper();
            builder.Services.ConfigurarInjecaoDependencia(builder.Configuration);
            builder.Services.ConfigurarSwagger();

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("Desenvolvimento", servicos => servicos.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            builder.Services.ConfigurarControllers();

            var app = builder.Build();

            app.UseMiddleware<ManipuladorExcecoes>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("Desenvolvimento");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}