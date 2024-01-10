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

            builder.HasOne(d => d.PokeItem)
            .WithMany(p => p.PokeList)
            .HasForeignKey(d => d.PokeItemId)
            .HasConstraintName("fk_poke_item_x_poke_pokemon")
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(c => c.PokeItemId, "idx_fk_poke_item_x_poke_pokemon");

            builder.HasOne(d => d.PokePrimaryType)
            .WithMany(p => p.PokePrimaryList)
            .HasForeignKey(d => d.PokePrimaryTypeId)
            .HasConstraintName("fk_poke_primary_type_x_poke_pokemon")
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(c => c.PokePrimaryTypeId, "idx_fk_poke_primary_type_x_poke_pokemon");

            builder.HasOne(d => d.PokeSecondaryType)
            .WithMany(p => p.PokeSecondaryList)
            .HasForeignKey(d => d.PokeSecondaryTypeId)
            .HasConstraintName("fk_poke_secondary_type_x_poke_pokemon")
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(c => c.PokeSecondaryTypeId, "idx_fk_poke_secondary_type_x_poke_pokemon");
        }
    }
}
