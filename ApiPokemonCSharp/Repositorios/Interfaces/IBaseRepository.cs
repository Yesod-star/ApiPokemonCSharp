using ApiPokemonCSharp.Models;

namespace ApiPokemonCSharp.Repositorios
{
    public interface IBaseRepository<TVmEntity> where TVmEntity : BaseModel
    {
        public Task<TVmEntity> AddItem(TVmEntity TVmEntity);

        public Task<bool> RemoveItem(int id);

        public Task<TVmEntity> UpdateItem(TVmEntity TVmEntity, int id);

        public Task<TVmEntity> SearchForId(int id);

        public Task<List<TVmEntity>> SearchAll();
    }
}