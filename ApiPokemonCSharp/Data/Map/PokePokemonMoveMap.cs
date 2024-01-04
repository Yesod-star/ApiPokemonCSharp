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

        builder.HasOne(x => x.PokeMove);
        builder.HasOne(x => x.PokePokemon);
    }
}
