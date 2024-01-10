using static ApiPokemonCSharp.Enums.GlobalTypes;

namespace ApiPokemonCSharp.Models;

public class PokeType :BaseModel
{
    public PokemonType PokemonType { get; set; }

    public virtual List<PokeEffective> PokeEffectiveList { get; set; }
    public virtual List<PokeWeakness> PokeWeaknessList { get; set; }
    public virtual List<PokeMove> PokeMoveList { get; set; }

    public virtual List<PokePokemon> PokePrimaryList { get; set; }

    public virtual List<PokePokemon> PokeSecondaryList { get; set; }

}

