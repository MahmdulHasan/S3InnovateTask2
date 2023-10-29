using App.Services.Buildings;
using App.Services.DateFields;
using App.Services.Object;


namespace App.Web.Framework.Factories
{
    public class DataFieldModelFactory : IDataFieldModelFactory
    {
        private readonly IDataFieldService _dataFieldService;

        public DataFieldModelFactory(IDataFieldService dataFieldService)
        {
            _dataFieldService = dataFieldService;
        }
        public async Task<List<DataFieldModel>> PrepareDataFieldModelList()
        {
            var objects = await _dataFieldService.GetDataFieldsAsync();

            return objects.Select(s => new DataFieldModel
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();
        }
    }
}
