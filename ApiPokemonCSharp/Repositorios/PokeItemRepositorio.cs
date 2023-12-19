using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;

namespace ApiPokemonCSharp.Repositorios;

public class PokeItemRepositorio : IPokeItemRepositorio
{
    public Task<PokeItem> Adicionar(PokeItem TVmEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokeItem> Atualizar(PokeItem TVmEntity, int id)
    {
        throw new NotImplementedException();
    }

    public Task<PokeItem> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PokeItem>> BuscarTodos()
    {
        throw new NotImplementedException();
    }
}
