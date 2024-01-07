using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokePokemonRepository : IPokePokemonRepository
{
    private readonly PokemonDbContext _dbContext;

    public PokePokemonRepository(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokePokemon> AddItem(PokePokemon TVmEntity)
    {
        await _dbContext.Pokemons.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> RemoveItem(int id)
    {
        PokePokemon PokePokemonId = await SearchForId(id);

        if (PokePokemonId != null)
        {
            throw new Exception($"Pokemon for Id: {id} was not found");
        }

        _dbContext.Pokemons.Remove(PokePokemonId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokePokemon> UpdateItem(PokePokemon TVmEntity, int id)
    {
        PokePokemon PokePokemonId = await SearchForId(id);

        if (PokePokemonId == null)
        {
            throw new Exception($"Pokemon for Id: {id} was not found");
        }

        PokePokemonId.Name = TVmEntity.Name;
        PokePokemonId.Deleted = TVmEntity.Deleted;
        PokePokemonId.DeletedWhen = TVmEntity.DeletedWhen;
        PokePokemonId.Id = TVmEntity.Id;
        PokePokemonId.SpeedPokemon  = TVmEntity.SpeedPokemon;
        PokePokemonId.HpPokemon = TVmEntity.HpPokemon;
        PokePokemonId.AttackPokemon = TVmEntity.AttackPokemon;
        PokePokemonId.DefensePokemon = TVmEntity.DefensePokemon;
        PokePokemonId.PokeItem = TVmEntity.PokeItem;
        PokePokemonId.PokeItemId = TVmEntity.PokeItemId;
        PokePokemonId.PokePokemonMoveList = TVmEntity.PokePokemonMoveList;
        PokePokemonId.PokePrimaryType = TVmEntity.PokePrimaryType;
        PokePokemonId.PokeTypePrimaryId = TVmEntity.PokeTypePrimaryId;
        PokePokemonId.PokeSecondaryType = TVmEntity.PokeSecondaryType;
        PokePokemonId.PokeTypeSecondaryId = TVmEntity.PokeTypeSecondaryId;
        PokePokemonId.SpecialAttackPokemon = TVmEntity.SpecialAttackPokemon;
        PokePokemonId.SpecialDefensePokemon = TVmEntity.SpecialDefensePokemon;

        _dbContext.Pokemons.Update(PokePokemonId);
        await _dbContext.SaveChangesAsync();

        return PokePokemonId;
    }

    public async Task<PokePokemon> SearchForId(int id)
    {
        return await _dbContext.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokePokemon>> SearchAll()
    {
        return await _dbContext.Pokemons.ToListAsync();
    }
}
