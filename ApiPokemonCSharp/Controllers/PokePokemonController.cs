using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokePokemonController : ControllerBase
    {
        private readonly IPokePokemonRepositorio _pokePokemonRepositorio;

        public PokePokemonController(IPokePokemonRepositorio pokePokemonRepositorio)
        {
            _pokePokemonRepositorio = pokePokemonRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PokePokemon>>> BuscarTodasTarefas()
        {
            List<PokePokemon> tarefas = await _pokePokemonRepositorio.BuscarTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokePokemon>> BuscarPorId(int id)
        {
            PokePokemon tarefa = await _pokePokemonRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<PokePokemon>> Cadastrar([FromBody] PokePokemon PokePokemon)
        {
            PokePokemon tarefa = await _pokePokemonRepositorio.Adicionar(PokePokemon);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokePokemon>> Atualizar([FromBody] PokePokemon PokePokemon, int id)
        {
            PokePokemon.Id = id;
            PokePokemon tarefa = await _pokePokemonRepositorio.Atualizar(PokePokemon, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokePokemon>> Apagar(int id)
        {
            bool apagado = await _pokePokemonRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
