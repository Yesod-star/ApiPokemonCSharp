using static ApiPokemonCSharp.Enums.GlobalTypes;

namespace ApiPokemonCSharp.Models;

public class PokeItem : BaseModel
{
    public int Price { get; set; }

    public PokemonAttribute AttributeBuff { get; set;}

    public int IncreaseBuff { get; set; }   
}

