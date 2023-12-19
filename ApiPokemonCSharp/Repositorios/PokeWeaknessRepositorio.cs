using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;

namespace ApiPokemonCSharp.Repositorios;

public class PokeWeaknessRepositorio : IPokeWeaknessRepositorio
{
    public Task<PokeType> Adicionar(PokeType TVmEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokeType> Atualizar(PokeType TVmEntity, int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokeType> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PokeType>> BuscarTodos()
    {
        throw new NotImplementedException();
    }
}

