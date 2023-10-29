using App.Data.Entities;

namespace App.Services.Buildings
{
    public interface IBuildingService
    {
        Task<List<Building>> GetBuildingsAsync();
    }
}
