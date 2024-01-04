using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPokemonCSharp.Data.Map;

public class PokeTypeMap : IEntityTypeConfiguration<PokeType>
{
    public void Configure(EntityTypeBuilder<PokeType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Deleted);
        builder.Property(x => x.DeletedWhen);
        builder.Property(x => x.PokemonType).IsRequired();

        builder.HasMany(x => x.PokeWeaknessList)
            .WithOne()
            .HasForeignKey("PokeTypeId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.PokeEffectiveList)
            .WithOne() 
            .HasForeignKey("PokeTypeId") 
            .OnDelete(DeleteBehavior.Cascade);
    }
}
