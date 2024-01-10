using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPokemonCSharp.Data.Map
{
    public class PokePokemonMap : IEntityTypeConfiguration<PokePokemon>
    {
        public void Configure(EntityTypeBuilder<PokePokemon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.DeletedWhen);
            builder.Property(x => x.HpPokemon).IsRequired();
            builder.Property(x => x.AttackPokemon).IsRequired();
            builder.Property(x => x.DefensePokemon).IsRequired();
            builder.Property(x => x.SpeedPokemon).IsRequired();
            builder.Property(x => x.SpecialAttackPokemon).IsRequired();
            builder.Property(x => x.SpecialDefensePokemon).IsRequired();
            builder.Property(x => x.PokeItemId).IsRequired();
            builder.Property(x => x.PokePrimaryTypeId).IsRequired();
            builder.Property(x => x.PokeSecondaryTypeId);

            builder.HasOne(x => x.PokeItem);

            builder.HasOne(x => x.PokePrimaryType);

            builder.HasOne(x => x.PokeSecondaryType);
        }
    }
}
