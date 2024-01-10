﻿using ApiPokemonCSharp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Data.Map;

public class PokeMoveMap : IEntityTypeConfiguration<PokeMove>
{
    public void Configure(EntityTypeBuilder<PokeMove> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Deleted);
        builder.Property(x => x.DeletedWhen);
        builder.Property(x => x.Damage);
        builder.Property(x => x.Velocity).IsRequired();
        builder.Property(x => x.ConditionChance);
        builder.Property(x => x.GeneratedCondition);
        builder.Property(x => x.AutoGeneratedConditionChance);
        builder.Property(x => x.AutoGeneratedCondition);
        builder.Property(x => x.PercentageBuff);
        builder.Property(x => x.AttributeBuff);
        builder.Property(x => x.PokeTypeId);

        builder.HasOne(d => d.PokeType)
         .WithMany(p => p.PokeMoveList)
         .HasForeignKey(d => d.PokeTypeId)
         .HasConstraintName("fk_poke_type_x_poke_move")
         .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(c => c.PokeTypeId, "idx_fk_poke_type_x_poke_move");
    }
}
