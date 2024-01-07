using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeItemController : ControllerBase
{
    private readonly IPokeItemRepository _pokeItemRepositorio;

    public PokeItemController(IPokeItemRepository pokeItemRepositorio)
    {
        _pokeItemRepositorio = pokeItemRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokeItem>>> SearchAll()
    {
        List<PokeItem> tarefas = await _pokeItemRepositorio.SearchAll();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokeItem>> SearchForId(int id)
    {
        PokeItem tarefa = await _pokeItemRepositorio.SearchForId(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<PokeItem>> AddItem([FromBody] PokeItem PokeItem)
    {
        PokeItem tarefa = await _pokeItemRepositorio.AddItem(PokeItem);
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PokeItem>> UpdateItem([FromBody] PokeItem PokeItem, int id)
    {
        PokeItem.Id = id;
        PokeItem tarefa = await _pokeItemRepositorio.UpdateItem(PokeItem, id);
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PokeItem>> RemoveItem(int id)
    {
        bool apagado = await _pokeItemRepositorio.RemoveItem(id);
        return Ok(apagado);
    }
}
