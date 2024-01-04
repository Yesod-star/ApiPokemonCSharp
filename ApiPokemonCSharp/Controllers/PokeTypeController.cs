using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeTypeController : ControllerBase
    {
        private readonly IPokeTypeRepositorio _pokeTypeRepositorio;

        public PokeTypeController(IPokeTypeRepositorio pokeTypeRepositorio)
        {
            _pokeTypeRepositorio = pokeTypeRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PokeType>>> BuscarTodasTarefas()
        {
            List<PokeType> tarefas = await _pokeTypeRepositorio.BuscarTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokeType>> BuscarPorId(int id)
        {
            PokeType tarefa = await _pokeTypeRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<PokeType>> Cadastrar([FromBody] PokeType PokeType)
        {
            PokeType tarefa = await _pokeTypeRepositorio.Adicionar(PokeType);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokeType>> Atualizar([FromBody] PokeType PokeType, int id)
        {
            PokeType.Id = id;
            PokeType tarefa = await _pokeTypeRepositorio.Atualizar(PokeType, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokeType>> Apagar(int id)
        {
            bool apagado = await _pokeTypeRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
