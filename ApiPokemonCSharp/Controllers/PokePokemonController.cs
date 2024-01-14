using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemonCSharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokePokemonController : ControllerBase
{
    private readonly IPokePokemonRepository _pokePokemonRepositorio;

    public PokePokemonController(IPokePokemonRepository pokePokemonRepositorio)
    {
        _pokePokemonRepositorio = pokePokemonRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokePokemon>>> SearchAll()
    {
        List<PokePokemon> tarefas = await _pokePokemonRepositorio.SearchAll();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokePokemon>> SearchForId(int id)
    {
        PokePokemon tarefa = await _pokePokemonRepositorio.SearchForId(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<PokePokemon>> AddItem([FromBody] PokePokemon PokePokemon)
    {
        PokePokemon tarefa = await _pokePokemonRepositorio.AddItem(PokePokemon);
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PokePokemon>> UpdateItem([FromBody] PokePokemon PokePokemon, int id)
    {
        PokePokemon.Id = id;
        PokePokemon tarefa = await _pokePokemonRepositorio.UpdateItem(PokePokemon, id);
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PokePokemon>> RemoveItem(int id)
    {
        bool apagado = await _pokePokemonRepositorio.RemoveItem(id);
        return Ok(apagado);
    }

	[HttpGet("{type}")]
	public async Task<ActionResult<List<PokePokemon>>> ShowAllPokemonByType(int type)
	{
		List<PokePokemon> PokeMoves = await _pokePokemonRepositorio.ShowAllPokemonByType(type);
		return Ok(PokeMoves);
	}

	[HttpGet("{move}")]
	public async Task<ActionResult<List<PokePokemon>>> ShowAllPokemonByMove(int move)
	{
		List<PokePokemon> PokeMoves = await _pokePokemonRepositorio.ShowAllPokemonByMove(move);
		return Ok(PokeMoves);
	}

    [HttpGet("Pokemon/{id}")]
    public async Task<ActionResult<List<PokePokemon>>> ShowAllDetailPokemon(int id)
    {
        List<PokePokemon> PokeMoves = await _pokePokemonRepositorio.ShowAllDetailPokemon(id);
        return Ok(PokeMoves);
    }
}
