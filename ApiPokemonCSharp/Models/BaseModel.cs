
namespace ApiPokemonCSharp.Models;

public class BaseModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool Deleted { get; set; }

    public DateTime DeletedWhen { get; set; }
}

