using App.Services.Buildings;
using App.Services.Object;


namespace App.Web.Framework.Factories
{
    public class ObjectModelFactory : IObjectModelFactory
    {
        private readonly IObjectService _objectService;

        public ObjectModelFactory(IObjectService objectService)
        {
            _objectService = objectService;
        }
        public async Task<List<ObjectModel>> PrepareObjectModelList()
        {
            var objects = await _objectService.GetObjectsAsync();

            return objects.Select(s => new ObjectModel
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();
        }
    }
}
