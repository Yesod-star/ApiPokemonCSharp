using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Data.Map;

public class PokeItemMap : IEntityTypeConfiguration<PokeItem>
{
    public void Configure(EntityTypeBuilder<PokeItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Deleted);
        builder.Property(x => x.DeletedWhen);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.AttributeBuff).IsRequired();
        builder.Property(x => x.IncreaseBuff).IsRequired();
    }
}
