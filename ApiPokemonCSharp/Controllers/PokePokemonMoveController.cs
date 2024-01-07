using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokePokemonMoveController : ControllerBase
{
    private readonly IPokePokemonMoveRepository _pokePokemonMoveRepositorio;

    public PokePokemonMoveController(IPokePokemonMoveRepository pokePokemonMoveRepositorio)
    {
        _pokePokemonMoveRepositorio = pokePokemonMoveRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokePokemonMove>>> SearchAll()
    {
        List<PokePokemonMove> tarefas = await _pokePokemonMoveRepositorio.SearchAll();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokePokemonMove>> SearchForId(int id)
    {
        PokePokemonMove tarefa = await _pokePokemonMoveRepositorio.SearchForId(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<PokePokemonMove>> AddItem([FromBody] PokePokemonMove PokePokemonMove)
    {
        PokePokemonMove tarefa = await _pokePokemonMoveRepositorio.AddItem(PokePokemonMove);
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PokePokemonMove>> UpdateItem([FromBody] PokePokemonMove PokePokemonMove, int id)
    {
        PokePokemonMove.Id = id;
        PokePokemonMove tarefa = await _pokePokemonMoveRepositorio.UpdateItem(PokePokemonMove, id);
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PokePokemonMove>> RemoveItem(int id)
    {
        bool apagado = await _pokePokemonMoveRepositorio.RemoveItem(id);
        return Ok(apagado);
    }
}
