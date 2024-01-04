using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeItemController : ControllerBase
    {
        private readonly IPokeItemRepositorio _pokeItemRepositorio;

        public PokeItemController(IPokeItemRepositorio pokeItemRepositorio)
        {
            _pokeItemRepositorio = pokeItemRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PokeItem>>> BuscarTodasTarefas()
        {
            List<PokeItem> tarefas = await _pokeItemRepositorio.BuscarTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokeItem>> BuscarPorId(int id)
        {
            PokeItem tarefa = await _pokeItemRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<PokeItem>> Cadastrar([FromBody] PokeItem PokeItem)
        {
            PokeItem tarefa = await _pokeItemRepositorio.Adicionar(PokeItem);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokeItem>> Atualizar([FromBody] PokeItem PokeItem, int id)
        {
            PokeItem.Id = id;
            PokeItem tarefa = await _pokeItemRepositorio.Atualizar(PokeItem, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokeItem>> Apagar(int id)
        {
            bool apagado = await _pokeItemRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
