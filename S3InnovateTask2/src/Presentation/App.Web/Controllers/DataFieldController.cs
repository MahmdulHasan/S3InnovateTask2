using App.Web.Framework.Factories;
using App.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFieldController : ControllerBase
    {
        private readonly IDataFieldModelFactory _dataFieldModelFactory;

        public DataFieldController(IDataFieldModelFactory dataFieldModelFactory)
        {
            _dataFieldModelFactory = dataFieldModelFactory;
        }
        
        [HttpGet(Name = "GetDataFields")]
        public async Task<List<DataFieldModel>> Get()
        {
            return await _dataFieldModelFactory.PrepareDataFieldModelList();
        }
    }
}
