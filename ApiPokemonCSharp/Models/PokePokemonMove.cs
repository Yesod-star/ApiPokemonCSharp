using static ApiPokemonCSharp.Enums.TiposGlobais;

namespace ApiPokemonCSharp.Models;

public class PokePokemonMove : BaseModel
{
    public int PokePokemonId { get; set; }

    public virtual PokePokemon? PokePokemon { get; set; }

    public int PokeMoveId { get; set; }

    public virtual PokeMove? PokeMove { get; set; }

}

