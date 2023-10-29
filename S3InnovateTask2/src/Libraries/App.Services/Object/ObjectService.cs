

namespace App.Services.Object
{
    public class ObjectService : IObjectService
    {
        private readonly IQueryRepository _repository;

        public ObjectService(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Objects>> GetObjectsAsync()
        {
            var objects = await _repository.Query<Objects>().ToListAsync();

            return objects;
        }
    }
}
