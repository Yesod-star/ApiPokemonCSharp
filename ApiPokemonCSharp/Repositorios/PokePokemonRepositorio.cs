using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;

namespace ApiPokemonCSharp.Repositorios;

public class PokePokemonRepositorio : IPokePokemonRepositorio
{
    public Task<PokePokemon> Adicionar(PokePokemon TVmEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokePokemon> Atualizar(PokePokemon TVmEntity, int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokePokemon> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PokePokemon>> BuscarTodos()
    {
        throw new NotImplementedException();
    }
}
