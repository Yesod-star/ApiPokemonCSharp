using ApiPokemonCSharp.Models;

namespace ApiPokemonCSharp.Repositorios
{
    public interface IBaseRepositorio<TVmEntity> where TVmEntity : BaseModel
    {
        public Task<TVmEntity> Adicionar(TVmEntity TVmEntity);

        public Task<bool> Apagar(int id);

        public Task<TVmEntity> Atualizar(TVmEntity TVmEntity, int id);

        public Task<TVmEntity> BuscarPorId(int id);

        public Task<List<TVmEntity>> BuscarTodos();
    }
}