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
        PokePokemonId.SpeedPokemon = TVmEntity.SpeedPokemon;
        PokePokemonId.HpPokemon = TVmEntity.HpPokemon;
        PokePokemonId.AttackPokemon = TVmEntity.AttackPokemon;
        PokePokemonId.DefensePokemon = TVmEntity.DefensePokemon;
        PokePokemonId.PokeItem = TVmEntity.PokeItem;
        PokePokemonId.PokeItemId = TVmEntity.PokeItemId;
        PokePokemonId.PokePokemonMoveList = TVmEntity.PokePokemonMoveList;
        PokePokemonId.PokePrimaryType = TVmEntity.PokePrimaryType;
        PokePokemonId.PokePrimaryTypeId = TVmEntity.PokePrimaryTypeId;
        PokePokemonId.PokeSecondaryType = TVmEntity.PokeSecondaryType;
        PokePokemonId.PokeSecondaryTypeId = TVmEntity.PokeSecondaryTypeId;
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

    public async Task<List<PokePokemon>> ShowAllPokemonByType(int type)
    {
        return await _dbContext.Pokemons.Where(x => x.PokePrimaryTypeId == type || x.PokeSecondaryTypeId == type).ToListAsync();
	}

	public async Task<List<PokePokemon>> ShowAllPokemonByMove(int move)
	{
		return await _dbContext.Pokemons
			.Include(y => y.PokePokemonMoveList)
			.ThenInclude(z => z.PokeMove)
			.Where(x => x.PokePokemonMoveList.Any(z => z.PokeMoveId == move))
			.ToListAsync();
	}

	public async Task<List<PokePokemon>> ShowAllDetailPokemon(int id)
	{
		return await _dbContext.Pokemons
			.Include(y => y.PokePokemonMoveList)
			.ThenInclude(z => z.PokeMove)
            .Include(a => a.PokePrimaryType)
            .ThenInclude(aAux => aAux.PokeWeaknessList)
            .ThenInclude(aAuxa => aAuxa.PokeType)
            .Include(b => b.PokeSecondaryType)
			.ThenInclude(bAux => bAux.PokeWeaknessList)
			.ThenInclude(bAuxa => bAuxa.PokeType)
			.Include(c => c.PokeItem)
			.ToListAsync();
	}
}
