using ApiPokemonCSharp.Data;
using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Repositorios;

public class PokeWeaknessRepositorio : IPokeWeaknessRepositorio
{

    private readonly PokemonDbContext _dbContext;

    public PokeWeaknessRepositorio(PokemonDbContext sistemaTarefasDbContext)
    {
        _dbContext = sistemaTarefasDbContext;
    }

    public async Task<PokeWeakness> Adicionar(PokeWeakness TVmEntity)
    {
        await _dbContext.Weakness.AddAsync(TVmEntity);
        await _dbContext.SaveChangesAsync();

        return TVmEntity;
    }

    public async Task<bool> Apagar(int id)
    {
        PokeWeakness PokeWeaknessId = await BuscarPorId(id);

        if (PokeWeaknessId != null)
        {
            throw new Exception($"Weakness for Id: {id} was not found");
        }

        _dbContext.Weakness.Remove(PokeWeaknessId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PokeWeakness> Atualizar(PokeWeakness TVmEntity, int id)
    {
        PokeWeakness PokeWeaknessId = await BuscarPorId(id);

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

    public async Task<PokeWeakness> BuscarPorId(int id)
    {
        return await _dbContext.Weakness.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PokeWeakness>> BuscarTodos()
    {
        return await _dbContext.Weakness.ToListAsync();
    }
}

