using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPokemonCSharp.Data.Map;

public class PokePokemonMoveMap : IEntityTypeConfiguration<PokePokemonMove>
{
    public void Configure(EntityTypeBuilder<PokePokemonMove> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Deleted);
        builder.Property(x => x.DeletedWhen);
        builder.Property(x => x.PokeMoveId).IsRequired();
        builder.Property(x => x.PokePokemonId).IsRequired();

        builder.HasOne(d => d.PokeMove)
        .WithMany(p => p.PokePokemonMoveList)
        .HasForeignKey(d => d.PokeMoveId)
        .HasConstraintName("fk_poke_move_x_poke_pokemon_move")
        .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(c => c.PokeMoveId, "idx_fk_poke_move_x_poke_pokemon_move");

        builder.HasOne(d => d.PokePokemon)
        .WithMany(p => p.PokePokemonMoveList)
        .HasForeignKey(d => d.PokePokemonId)
        .HasConstraintName("fk_poke_pokemon_x_poke_pokemon_move")
        .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(c => c.PokePokemonId, "idx_fk_poke_pokemon_x_poke_pokemon_move");
    }
}
