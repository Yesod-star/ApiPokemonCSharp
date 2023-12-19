using static ApiPokemonCSharp.Enums.TiposGlobais;

namespace ApiPokemonCSharp.Models;

public class PokeWeakness : BaseModel
{
    public PokemonType PokemonType { get; set; }

    public int Multiplicador { get; set; }
}

