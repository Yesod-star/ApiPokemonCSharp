using ApiPokemonCSharp.Models;
using ApiPokemonCSharp.Repositorios.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemonCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeWeaknessController : ControllerBase
    {
        private readonly IPokeWeaknessRepositorio _pokeWeaknessRepositorio;

        public PokeWeaknessController(IPokeWeaknessRepositorio pokeWeaknessRepositorio)
        {
            _pokeWeaknessRepositorio = pokeWeaknessRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PokeWeakness>>> BuscarTodasTarefas()
        {
            List<PokeWeakness> tarefas = await _pokeWeaknessRepositorio.BuscarTodos();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokeWeakness>> BuscarPorId(int id)
        {
            PokeWeakness tarefa = await _pokeWeaknessRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<PokeWeakness>> Cadastrar([FromBody] PokeWeakness PokeWeakness)
        {
            PokeWeakness tarefa = await _pokeWeaknessRepositorio.Adicionar(PokeWeakness);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokeWeakness>> Atualizar([FromBody] PokeWeakness PokeWeakness, int id)
        {
            PokeWeakness.Id = id;
            PokeWeakness tarefa = await _pokeWeaknessRepositorio.Atualizar(PokeWeakness, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokeWeakness>> Apagar(int id)
        {
            bool apagado = await _pokeWeaknessRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
