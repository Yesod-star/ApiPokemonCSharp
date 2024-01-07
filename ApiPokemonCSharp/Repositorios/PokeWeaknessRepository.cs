using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokeWeaknessRepository : IPokeWeaknessRepository
{

    private readonly PokemonDbContext _dbContext;

    public PokeWeaknessRepository(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokeWeakness> AddItem(PokeWeakness TVmEntity)
    {
        await _dbContext.Weakness.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> RemoveItem(int id)
    {
        PokeWeakness PokeWeaknessId = await SearchForId(id);

        if (PokeWeaknessId != null)
        {
            throw new Exception($"Weakness for Id: {id} was not found");
        }

        _dbContext.Weakness.Remove(PokeWeaknessId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokeWeakness> UpdateItem(PokeWeakness TVmEntity, int id)
    {
        PokeWeakness PokeWeaknessId = await SearchForId(id);

        if (PokeWeaknessId == null)
        {
            throw new Exception($"Weakness for Id: {id} was not found");
        }

        PokeWeaknessId.Name = TVmEntity.Name;
        PokeWeaknessId.Deleted = TVmEntity.Deleted;
        PokeWeaknessId.DeletedWhen = TVmEntity.DeletedWhen;
        PokeWeaknessId.Id = TVmEntity.Id;
        PokeWeaknessId.PokeTypeId = TVmEntity.PokeTypeId;
        PokeWeaknessId.PokeType = TVmEntity.PokeType;
        PokeWeaknessId.Multiplier = TVmEntity.Multiplier;

        _dbContext.Weakness.Update(PokeWeaknessId);
        await _dbContext.SaveChangesAsync();

        return PokeWeaknessId;
    }

    public async Task<PokeWeakness> SearchForId(int id)
    {
        return await _dbContext.Weakness.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokeWeakness>> SearchAll()
    {
        return await _dbContext.Weakness.ToListAsync();
    }
}

