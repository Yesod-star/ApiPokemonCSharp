using static ApiPokemonCSharp.Enums.TiposGlobais;

namespace ApiPokemonCSharp.Models;

public class PokeType :BaseModel
{
    public PokemonType PokemonType { get; set; }

    public List<PokeWeakness>? PokeWeaknessList { get; set;}

    public List<PokeEffective>? PokeEffectiveList { get; set;}
}

