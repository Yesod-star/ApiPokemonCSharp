using ApiPokemonCSharp.Data.Map;
using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ApiPokemonCSharp.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }

        public DbSet<PokeEffective> Effectiveness { get; set; }
        public DbSet<PokeItem> Items { get; set; }
        public DbSet<PokeMove> Moves { get; set; }
        public DbSet<PokePokemon> Pokemons { get; set; }
        public DbSet<PokeType> Types { get; set; }
        public DbSet<PokeWeakness> Weakness { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokeEffectiveMap());
            modelBuilder.ApplyConfiguration(new PokeItemMap());
            modelBuilder.ApplyConfiguration(new PokeMoveMap());
            modelBuilder.ApplyConfiguration(new PokePokemonMap());
            modelBuilder.ApplyConfiguration(new PokeTypeMap());
            modelBuilder.ApplyConfiguration(new PokeWeaknessMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
