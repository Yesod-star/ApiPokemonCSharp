using ApiPokemonCSharp.Models;

namespace ApiPokemonCSharp.Repositorios.Repositorios;

public interface IPokeTypeRepository : IBaseRepository<PokeType>
{
	public Task<List<PokeType>> ShowAllWeaknessByType(int type);
	public Task<List<PokeType>> ShowAllEffectivenessByType(int type);
}
