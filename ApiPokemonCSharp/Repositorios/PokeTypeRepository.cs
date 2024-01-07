using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokeTypeRepository : IPokeTypeRepository
{

    private readonly PokemonDbContext _dbContext;

    public PokeTypeRepository(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokeType> AddItem(PokeType TVmEntity)
    {
        await _dbContext.Types.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> RemoveItem(int id)
    {
        PokeType PokeTypeId = await SearchForId(id);

        if (PokeTypeId != null)
        {
            throw new Exception($"Type for Id: {id} was not found");
        }

        _dbContext.Types.Remove(PokeTypeId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokeType> UpdateItem(PokeType TVmEntity, int id)
    {
        PokeType PokeTypeId = await SearchForId(id);

        if (PokeTypeId == null)
        {
            throw new Exception($"Type for Id: {id} was not found");
        }

        PokeTypeId.Name = TVmEntity.Name;
        PokeTypeId.Deleted = TVmEntity.Deleted;
        PokeTypeId.DeletedWhen = TVmEntity.DeletedWhen;
        PokeTypeId.Id = TVmEntity.Id;
        PokeTypeId.PokemonType = TVmEntity.PokemonType;
        PokeTypeId.PokeEffectiveList = TVmEntity.PokeEffectiveList;
        PokeTypeId.PokeWeaknessList = TVmEntity.PokeWeaknessList;

        _dbContext.Types.Update(PokeTypeId);
        await _dbContext.SaveChangesAsync();

        return PokeTypeId;
    }

    public async Task<PokeType> SearchForId(int id)
    {
        return await _dbContext.Types.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokeType>> SearchAll()
    {
        return await _dbContext.Types.ToListAsync();
    }
}

