using static ApiPokemonCSharp.Enums.TiposGlobais;

namespace ApiPokemonCSharp.Models;

public class PokeEffective : BaseModel
{
    public PokemonType PokemonType { get; set; }

    public int Multiplier { get; set; }
}

