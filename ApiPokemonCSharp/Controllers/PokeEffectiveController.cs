using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeEffectiveController : ControllerBase
    {
        private readonly IPokeEffectiveRepositorio _pokeEffectiveRepositorio;

        public PokeEffectiveController(IPokeEffectiveRepositorio pokeEffectiveRepositorio)
        {
            _pokeEffectiveRepositorio = pokeEffectiveRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PokeEffective>>> BuscarTodasTarefas()
        {
            List<PokeEffective> tarefas = await _pokeEffectiveRepositorio.BuscarTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokeEffective>> BuscarPorId(int id)
        {
            PokeEffective tarefa = await _pokeEffectiveRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<PokeEffective>> Cadastrar([FromBody] PokeEffective PokeEffective)
        {
            PokeEffective tarefa = await _pokeEffectiveRepositorio.Adicionar(PokeEffective);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokeEffective>> Atualizar([FromBody] PokeEffective PokeEffective, int id)
        {
            PokeEffective.Id = id;
            PokeEffective tarefa = await _pokeEffectiveRepositorio.Atualizar(PokeEffective, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokeEffective>> Apagar(int id)
        {
            bool apagado = await _pokeEffectiveRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
