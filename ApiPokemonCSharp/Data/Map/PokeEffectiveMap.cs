using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPokemonCSharp.Data.Map
{
    public class PokeEffectiveMap : IEntityTypeConfiguration<PokeEffective>
    {
        public void Configure(EntityTypeBuilder<PokeEffective> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.DeletedWhen);
            builder.Property(x => x.PokemonType).IsRequired();
            builder.Property(x => x.Multiplier).IsRequired();

        }
    }
}
