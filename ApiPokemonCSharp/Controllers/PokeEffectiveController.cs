using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeEffectiveController : ControllerBase
{
    private readonly IPokeEffectiveRepository _pokeEffectiveRepositorio;

    public PokeEffectiveController(IPokeEffectiveRepository pokeEffectiveRepositorio)
    {
        _pokeEffectiveRepositorio = pokeEffectiveRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokeEffective>>> SearchAll()
    {
        List<PokeEffective> tarefas = await _pokeEffectiveRepositorio.SearchAll();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokeEffective>> SearchForId(int id)
    {
        PokeEffective tarefa = await _pokeEffectiveRepositorio.SearchForId(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<PokeEffective>> AddItem([FromBody] PokeEffective PokeEffective)
    {
        PokeEffective tarefa = await _pokeEffectiveRepositorio.AddItem(PokeEffective);
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PokeEffective>> UpdateItem([FromBody] PokeEffective PokeEffective, int id)
    {
        PokeEffective.Id = id;
        PokeEffective tarefa = await _pokeEffectiveRepositorio.UpdateItem(PokeEffective, id);
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PokeEffective>> RemoveItem(int id)
    {
        bool apagado = await _pokeEffectiveRepositorio.RemoveItem(id);
        return Ok(apagado);
    }
}
