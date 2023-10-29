using App.Services.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Framework.Factories
{
    public class BuildingModelFactory : IBuildingModelFactory
    {
        private readonly IBuildingService _buildingService;

        public BuildingModelFactory(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        public async Task<List<BuildingModel>> PrepareBuildingModelList()
        {
            var buildings = await _buildingService.GetBuildingsAsync();

            return buildings.Select(s => new BuildingModel
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();
        }
    }
}
