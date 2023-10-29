


namespace App.Services.Buildings
{
    public class BuildingService : IBuildingService
    {
        private readonly IQueryRepository _repository;

        public BuildingService(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Building>> GetBuildingsAsync()
        {
            var buildings = await _repository.Query<Building>().ToListAsync();

            return buildings;
        }
    }
}
