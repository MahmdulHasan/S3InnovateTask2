using App.Web.Framework.Factories;
using App.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IReadingModelFactory _readingModelFactory;

        public ReadingController(IReadingModelFactory readingModelFactory)
        {
            _readingModelFactory = readingModelFactory;
        }

        [HttpGet(Name = "GetTimeSeriesData")]
        public async Task<List<ReadingModel>> Get(int buildingId, int objectId, int dataFieldId, DateTime startDate, DateTime endDate)
        {
            return await _readingModelFactory.GetTimeSeriesData(buildingId, objectId, dataFieldId,
                startDate, endDate);
        }
    }
}
