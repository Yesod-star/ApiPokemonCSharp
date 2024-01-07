using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokeItemRepository : IPokeItemRepository
{
    private readonly PokemonDbContext _dbContext;

    public PokeItemRepository(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokeItem> AddItem(PokeItem TVmEntity)
    {
        await _dbContext.Items.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> RemoveItem(int id)
    {
        PokeItem PokeItemId = await SearchForId(id);

        if (PokeItemId != null)
        {
            throw new Exception($"Item for Id: {id} was not found");
        }

        _dbContext.Items.Remove(PokeItemId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokeItem> UpdateItem(PokeItem TVmEntity, int id)
    {
        PokeItem PokeItemId = await SearchForId(id);

        if (PokeItemId == null)
        {
            throw new Exception($"Item for Id: {id} was not found");
        }

        PokeItemId.Name = TVmEntity.Name;
        PokeItemId.Deleted = TVmEntity.Deleted;
        PokeItemId.DeletedWhen = TVmEntity.DeletedWhen;
        PokeItemId.Id = TVmEntity.Id;
        PokeItemId.AttributeBuff = TVmEntity.AttributeBuff;
        PokeItemId.IncreaseBuff = TVmEntity.IncreaseBuff;
        PokeItemId.Price = TVmEntity.Price;

        _dbContext.Items.Update(PokeItemId);
        await _dbContext.SaveChangesAsync();

        return PokeItemId;
    }

    public async Task<PokeItem> SearchForId(int id)
    {
        return await _dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokeItem>> SearchAll()
    {
        return await _dbContext.Items.ToListAsync();
    }
}
