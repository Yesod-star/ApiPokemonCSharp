using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;

namespace ApiPokemonCSharp.Repositorios;

public class PokeMoveRepositorio : IPokeMoveRepositorio
{
    public Task<PokeMove> Adicionar(PokeMove TVmEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokeMove> Atualizar(PokeMove TVmEntity, int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokeMove> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PokeMove>> BuscarTodos()
    {
        throw new NotImplementedException();
    }
}
