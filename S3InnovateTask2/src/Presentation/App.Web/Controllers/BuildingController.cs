using App.Services.Buildings;
using App.Web.Framework.Factories;
using App.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingModelFactory _buildingModelFactory;

        public BuildingController(IBuildingModelFactory buildingModelFactory)
        {
            _buildingModelFactory = buildingModelFactory;
        }

        [HttpGet(Name = "GetBuildings")]
        public async Task<List<BuildingModel>> Get()
        {
            return await _buildingModelFactory.PrepareBuildingModelList();
        }
    }
}
