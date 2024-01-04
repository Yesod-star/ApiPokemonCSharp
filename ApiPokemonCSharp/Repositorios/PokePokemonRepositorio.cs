using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokePokemonRepositorio : IPokePokemonRepositorio
{
    private readonly PokemonDbContext _dbContext;

    public PokePokemonRepositorio(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokePokemon> Adicionar(PokePokemon TVmEntity)
    {
        await _dbContext.Pokemons.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> Apagar(int id)
    {
        PokePokemon PokePokemonId = await BuscarPorId(id);

        if (PokePokemonId != null)
        {
            throw new Exception($"Pokemon for Id: {id} was not found");
        }

        _dbContext.Pokemons.Remove(PokePokemonId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokePokemon> Atualizar(PokePokemon TVmEntity, int id)
    {
        PokePokemon PokePokemonId = await BuscarPorId(id);

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

    public async Task<PokePokemon> BuscarPorId(int id)
    {
        return await _dbContext.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokePokemon>> BuscarTodos()
    {
        return await _dbContext.Pokemons.ToListAsync();
    }
}
