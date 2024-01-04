using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokeEffectiveRepositorio : IPokeEffectiveRepositorio
{
    private readonly PokemonDbContext _dbContext;

    public PokeEffectiveRepositorio(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokeEffective> Adicionar(PokeEffective TVmEntity)
    {
        await _dbContext.Effectiveness.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> Apagar(int id)
    {
        PokeEffective pokeEffectiveId = await BuscarPorId(id);

        if (pokeEffectiveId != null)
        {
            throw new Exception($"Effectiveness for Id: {id} was not found");
        }

        _dbContext.Effectiveness.Remove(pokeEffectiveId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokeEffective> Atualizar(PokeEffective TVmEntity, int id)
    {
        PokeEffective PokeEffectiveId = await BuscarPorId(id);

        if (PokeEffectiveId == null)
        {
            throw new Exception($"Effectiveness for Id: {id} was not found");
        }

        PokeEffectiveId.Name = TVmEntity.Name;
        PokeEffectiveId.Deleted = TVmEntity.Deleted;
        PokeEffectiveId.DeletedWhen = TVmEntity.DeletedWhen;
        PokeEffectiveId.Id = TVmEntity.Id;
        PokeEffectiveId.PokeTypeId = TVmEntity.PokeTypeId;
        PokeEffectiveId.PokeType = TVmEntity.PokeType;
        PokeEffectiveId.Multiplier = TVmEntity.Multiplier;

        _dbContext.Effectiveness.Update(PokeEffectiveId);
        await _dbContext.SaveChangesAsync();

        return PokeEffectiveId;
    }

    public async Task<PokeEffective> BuscarPorId(int id)
    {
        return await _dbContext.Effectiveness.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokeEffective>> BuscarTodos()
    {
        return await _dbContext.Effectiveness.ToListAsync();
    }
}
