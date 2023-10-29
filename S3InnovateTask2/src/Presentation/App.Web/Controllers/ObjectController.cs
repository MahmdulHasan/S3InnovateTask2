using App.Web.Framework.Factories;
using App.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly IObjectModelFactory _objectModelFactory;

        public ObjectController(IObjectModelFactory objectModelFactory)
        {
            _objectModelFactory = objectModelFactory;
        }

        [HttpGet(Name = "GetObjects")]
        public async Task<List<ObjectModel>> Get()
        {
            return await _objectModelFactory.PrepareObjectModelList();
        }
    }
}
