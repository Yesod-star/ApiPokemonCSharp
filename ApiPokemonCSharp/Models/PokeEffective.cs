using static ApiPokemonCSharp.Enums.TiposGlobais;

namespace ApiPokemonCSharp.Models;

public class PokeEffective : BaseModel
{
    public int Multiplier { get; set; }

    public int PokeTypeId { get; set; }

    public virtual PokeType? PokeType { get; set; }

}

