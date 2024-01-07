using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeWeaknessController : ControllerBase
{
    private readonly IPokeWeaknessRepository _pokeWeaknessRepositorio;

    public PokeWeaknessController(IPokeWeaknessRepository pokeWeaknessRepositorio)
    {
        _pokeWeaknessRepositorio = pokeWeaknessRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokeWeakness>>> SearchAll()
    {
        List<PokeWeakness> tarefas = await _pokeWeaknessRepositorio.SearchAll();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokeWeakness>> SearchForId(int id)
    {
        PokeWeakness tarefa = await _pokeWeaknessRepositorio.SearchForId(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<PokeWeakness>> AddItem([FromBody] PokeWeakness PokeWeakness)
    {
        PokeWeakness tarefa = await _pokeWeaknessRepositorio.AddItem(PokeWeakness);
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PokeWeakness>> UpdateItem([FromBody] PokeWeakness PokeWeakness, int id)
    {
        PokeWeakness.Id = id;
        PokeWeakness tarefa = await _pokeWeaknessRepositorio.UpdateItem(PokeWeakness, id);
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PokeWeakness>> RemoveItem(int id)
    {
        bool apagado = await _pokeWeaknessRepositorio.RemoveItem(id);
        return Ok(apagado);
    }
}
