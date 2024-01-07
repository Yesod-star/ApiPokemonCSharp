using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Repositorios;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp;

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
        .AddDbContext<PokemonDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
        );

        builder.Services.AddScoped<IPokeEffectiveRepository,PokeEffectiveRepository>();
        builder.Services.AddScoped<IPokeItemRepository, PokeItemRepository>();
        builder.Services.AddScoped<IPokeMoveRepository, PokeMoveRepository>();
        builder.Services.AddScoped<IPokePokemonMoveRepository, PokePokemonMoveRepository>();
        builder.Services.AddScoped<IPokePokemonRepository, PokePokemonRepository>();
        builder.Services.AddScoped<IPokeTypeRepository, PokeTypeRepository>();
        builder.Services.AddScoped<IPokeWeaknessRepository, PokeWeaknessRepository>();

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
