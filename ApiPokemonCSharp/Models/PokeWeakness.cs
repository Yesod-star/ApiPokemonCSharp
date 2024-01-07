using static ApiPokemonCSharp.Enums.GlobalTypes;

namespace ApiPokemonCSharp.Models;

public class PokeWeakness : BaseModel
{
    public int Multiplier { get; set; }

    public int PokeTypeId { get; set; }

    public virtual PokeType? PokeType { get; set; }
}

