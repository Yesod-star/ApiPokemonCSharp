using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokePokemonMoveController : ControllerBase
    {
        private readonly IPokePokemonMoveRepositorio _pokePokemonMoveRepositorio;

        public PokePokemonMoveController(IPokePokemonMoveRepositorio pokePokemonMoveRepositorio)
        {
            _pokePokemonMoveRepositorio = pokePokemonMoveRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PokePokemonMove>>> BuscarTodasTarefas()
        {
            List<PokePokemonMove> tarefas = await _pokePokemonMoveRepositorio.BuscarTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokePokemonMove>> BuscarPorId(int id)
        {
            PokePokemonMove tarefa = await _pokePokemonMoveRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<PokePokemonMove>> Cadastrar([FromBody] PokePokemonMove PokePokemonMove)
        {
            PokePokemonMove tarefa = await _pokePokemonMoveRepositorio.Adicionar(PokePokemonMove);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokePokemonMove>> Atualizar([FromBody] PokePokemonMove PokePokemonMove, int id)
        {
            PokePokemonMove.Id = id;
            PokePokemonMove tarefa = await _pokePokemonMoveRepositorio.Atualizar(PokePokemonMove, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokePokemonMove>> Apagar(int id)
        {
            bool apagado = await _pokePokemonMoveRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
