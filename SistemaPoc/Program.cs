using Microsoft.EntityFrameworkCore;
using SistemaPoc.Data;
using SistemaPoc.Repositorys;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc
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
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaPocDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();
            builder.Services.AddScoped<IAdvogadoRepository, AdvogadoRepository>();
            builder.Services.AddScoped<IReclamanteRepository, ReclamanteRepository>();
            builder.Services.AddScoped<IReclamadaRepository, ReclamadaRepository>();

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