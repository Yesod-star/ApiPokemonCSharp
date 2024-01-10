using static ApiPokemonCSharp.Enums.GlobalTypes;

namespace ApiPokemonCSharp.Models;

public class PokePokemon : BaseModel
{
    public int HpPokemon {  get; set; }

    public int AttackPokemon { get; set; }

    public int DefensePokemon { get; set; }

    public int SpeedPokemon { get; set; }

    public int SpecialAttackPokemon { get; set; }

    public int SpecialDefensePokemon { get; set; }
    public int PokeItemId { get; set; }

    public PokeItem? PokeItem { get; set; }

    public int PokePrimaryTypeId { get; set; }

    public virtual PokeType? PokePrimaryType { get; set; }

    public int? PokeSecondaryTypeId { get; set; }

    public virtual PokeType? PokeSecondaryType { get; set; }

    public List<PokePokemonMove>? PokePokemonMoveList { get; set; }
}

