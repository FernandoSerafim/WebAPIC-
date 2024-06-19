
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas
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

            builder.Services.AddDbContext<SistemaTarefasDbContex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SistemaTarefasDbContext")));

            //Toda vez que a minha IClienteRepositorio for chamada, eu quero que
            //a CLiente Repositorio resolva a interface
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            //builder.Services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            //builder.Services.AddScoped<IClienteEnderecoApp, ClienteEnderecoApp>();

            ////Adicionando a configuração do automapper
            //builder.Services.AddAutoMapper(typeof(ClienteProfile));

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
