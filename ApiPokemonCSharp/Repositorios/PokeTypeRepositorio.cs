using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokeTypeRepositorio : IPokeTypeRepositorio
{

    private readonly PokemonDbContext _dbContext;

    public PokeTypeRepositorio(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokeType> Adicionar(PokeType TVmEntity)
    {
        await _dbContext.Types.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> Apagar(int id)
    {
        PokeType PokeTypeId = await BuscarPorId(id);

        if (PokeTypeId != null)
        {
            throw new Exception($"Type for Id: {id} was not found");
        }

        _dbContext.Types.Remove(PokeTypeId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokeType> Atualizar(PokeType TVmEntity, int id)
    {
        PokeType PokeTypeId = await BuscarPorId(id);

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

    public async Task<PokeType> BuscarPorId(int id)
    {
        return await _dbContext.Types.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokeType>> BuscarTodos()
    {
        return await _dbContext.Types.ToListAsync();
    }
}

