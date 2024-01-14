using ApiPokemonCSharp.Models;

namespace ApiPokemonCSharp.Repositorios.Repositorios;

public interface IPokeMoveRepository : IBaseRepository<PokeMove>
{
	public Task<List<PokeMove>> ShowAllMoveByType(int type);

	public Task<List<PokeMove>> ShowAllMoveByPokemon(int pokemon);
}

