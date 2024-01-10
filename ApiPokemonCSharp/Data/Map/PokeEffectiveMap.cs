using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPokemonCSharp.Data.Map;

public class PokeEffectiveMap : IEntityTypeConfiguration<PokeEffective>
{
    public void Configure(EntityTypeBuilder<PokeEffective> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Deleted);
        builder.Property(x => x.DeletedWhen);
        builder.Property(x => x.Multiplier).IsRequired();
        builder.Property(x => x.PokeTypeId).IsRequired();

        builder.HasOne(d => d.PokeType)
         .WithMany(p => p.PokeEffectiveList)
         .HasForeignKey(d => d.PokeTypeId)
         .HasConstraintName("fk_poke_type_x_poke_effective")
         .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(c => c.PokeTypeId, "idx_fk_poke_type_x_poke_effective");
    }
}
