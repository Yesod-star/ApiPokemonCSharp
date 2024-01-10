using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPokemonCSharp.Data.Map;

public class PokeWeaknessMap : IEntityTypeConfiguration<PokeWeakness>
{
    public void Configure(EntityTypeBuilder<PokeWeakness> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Deleted);
        builder.Property(x => x.DeletedWhen);
        builder.Property(x => x.PokeTypeId).IsRequired();
        builder.Property(x => x.Multiplier).IsRequired();

        builder.HasOne(d => d.PokeType)
         .WithMany(p => p.PokeWeaknessList)
         .HasForeignKey(d => d.PokeTypeId)
         .HasConstraintName("fk_poke_type_x_poke_weakness")
         .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(c => c.PokeTypeId, "idx_fk_poke_type_x_poke_weakness");
    }
}
