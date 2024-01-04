using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeMoveController : ControllerBase
    {
        private readonly IPokeMoveRepositorio _pokeMoveRepositorio;

        public PokeMoveController(IPokeMoveRepositorio pokeMoveRepositorio)
        {
            _pokeMoveRepositorio = pokeMoveRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PokeMove>>> BuscarTodasTarefas()
        {
            List<PokeMove> tarefas = await _pokeMoveRepositorio.BuscarTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokeMove>> BuscarPorId(int id)
        {
            PokeMove tarefa = await _pokeMoveRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<PokeMove>> Cadastrar([FromBody] PokeMove PokeMove)
        {
            PokeMove tarefa = await _pokeMoveRepositorio.Adicionar(PokeMove);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokeMove>> Atualizar([FromBody] PokeMove PokeMove, int id)
        {
            PokeMove.Id = id;
            PokeMove tarefa = await _pokeMoveRepositorio.Atualizar(PokeMove, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokeMove>> Apagar(int id)
        {
            bool apagado = await _pokeMoveRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
