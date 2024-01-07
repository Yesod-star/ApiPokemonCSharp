using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeMoveController : ControllerBase
{
    private readonly IPokeMoveRepository _pokeMoveRepositorio;

    public PokeMoveController(IPokeMoveRepository pokeMoveRepositorio)
    {
        _pokeMoveRepositorio = pokeMoveRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokeMove>>> SearchAll()
    {
        List<PokeMove> tarefas = await _pokeMoveRepositorio.SearchAll();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokeMove>> SearchForId(int id)
    {
        PokeMove tarefa = await _pokeMoveRepositorio.SearchForId(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<PokeMove>> AddItem([FromBody] PokeMove PokeMove)
    {
        PokeMove tarefa = await _pokeMoveRepositorio.AddItem(PokeMove);
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PokeMove>> UpdateItem([FromBody] PokeMove PokeMove, int id)
    {
        PokeMove.Id = id;
        PokeMove tarefa = await _pokeMoveRepositorio.UpdateItem(PokeMove, id);
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PokeMove>> RemoveItem(int id)
    {
        bool apagado = await _pokeMoveRepositorio.RemoveItem(id);
        return Ok(apagado);
    }
}
