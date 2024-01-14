using ApiPokemonCSharp.Models;

namespace ApiPokemonCSharp.Repositorios.Repositorios;

public interface IPokePokemonRepository : IBaseRepository<PokePokemon>
{
	public Task<List<PokePokemon>> ShowAllPokemonByType(int type);

	public Task<List<PokePokemon>> ShowAllPokemonByMove(int move);

	public Task<List<PokePokemon>> ShowAllDetailPokemon(int id);
}
