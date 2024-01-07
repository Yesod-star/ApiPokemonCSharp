using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokePokemonMoveRepository : IPokePokemonMoveRepository
{
    private readonly PokemonDbContext _dbContext;

    public PokePokemonMoveRepository(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokePokemonMove> AddItem(PokePokemonMove TVmEntity)
    {
        await _dbContext.PokemonMove.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> RemoveItem(int id)
    {
        PokePokemonMove PokePokemonMoveId = await SearchForId(id);

        if (PokePokemonMoveId != null)
        {
            throw new Exception($"Pokemon Move for Id: {id} was not found");
        }

        _dbContext.PokemonMove.Remove(PokePokemonMoveId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokePokemonMove> UpdateItem(PokePokemonMove TVmEntity, int id)
    {
        PokePokemonMove PokePokemonMoveId = await SearchForId(id);

        if (PokePokemonMoveId == null)
        {
            throw new Exception($"Move for Id: {id} was not found");
        }

        PokePokemonMoveId.Name = TVmEntity.Name;
        PokePokemonMoveId.Deleted = TVmEntity.Deleted;
        PokePokemonMoveId.DeletedWhen = TVmEntity.DeletedWhen;
        PokePokemonMoveId.Id = TVmEntity.Id;
        PokePokemonMoveId.PokePokemonId = TVmEntity.PokePokemonId;
        PokePokemonMoveId.PokePokemon = TVmEntity.PokePokemon;
        PokePokemonMoveId.PokeMove = TVmEntity.PokeMove;
        PokePokemonMoveId.PokeMoveId = TVmEntity.PokeMoveId;

        _dbContext.PokemonMove.Update(PokePokemonMoveId);
        await _dbContext.SaveChangesAsync();

        return PokePokemonMoveId;
    }

    public async Task<PokePokemonMove> SearchForId(int id)
    {
        return await _dbContext.PokemonMove.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokePokemonMove>> SearchAll()
    {
        return await _dbContext.PokemonMove.ToListAsync();
    }
}
