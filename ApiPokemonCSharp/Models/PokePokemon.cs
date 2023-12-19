using static ApiPokemonCSharp.Enums.TiposGlobais;

namespace ApiPokemonCSharp.Models;

public class PokePokemon : BaseModel
{
    public PokemonType PokemonPrimaryType { get; set; }

    public PokemonType PokemonSecondaryType { get; set; }

    public PokeItem? PokeItem { get; set; }

    public int HpPokemon {  get; set; }

    public int AttackPokemon { get; set; }

    public int DefensePokemon { get; set; }

    public int SpeedPokemon { get; set; }

    public int SpecialAttackPokemon { get; set; }

    public int SpecialDefensePokemon { get; set; }

    public List<PokeMove>? PokeMoveList { get; set; }
}

