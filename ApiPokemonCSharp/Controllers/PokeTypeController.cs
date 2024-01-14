using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeTypeController : ControllerBase
{
    private readonly IPokeTypeRepository _pokeTypeRepositorio;

    public PokeTypeController(IPokeTypeRepository pokeTypeRepositorio)
    {
        _pokeTypeRepositorio = pokeTypeRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokeType>>> SearchAll()
    {
        List<PokeType> tarefas = await _pokeTypeRepositorio.SearchAll();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokeType>> SearchForId(int id)
    {
        PokeType tarefa = await _pokeTypeRepositorio.SearchForId(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<PokeType>> AddItem([FromBody] PokeType PokeType)
    {
        PokeType tarefa = await _pokeTypeRepositorio.AddItem(PokeType);
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PokeType>> UpdateItem([FromBody] PokeType PokeType, int id)
    {
        PokeType.Id = id;
        PokeType tarefa = await _pokeTypeRepositorio.UpdateItem(PokeType, id);
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PokeType>> RemoveItem(int id)
    {
        bool apagado = await _pokeTypeRepositorio.RemoveItem(id);
        return Ok(apagado);
    }

	[HttpGet("{type}")]
	public async Task<ActionResult<List<PokeType>>> ShowAllWeaknessByType(int type)
	{
		List<PokeType> PokeTypes = await _pokeTypeRepositorio.ShowAllWeaknessByType(type);
		return Ok(PokeTypes);
	}

	[HttpGet("{type}")]
	public async Task<ActionResult<List<PokeType>>> ShowAllEffectivenessByType(int type)
	{
		List<PokeType> PokeTypes = await _pokeTypeRepositorio.ShowAllEffectivenessByType(type);
		return Ok(PokeTypes);
	}
}
