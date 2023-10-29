

namespace App.Web.Framework.Factories
{
    public interface IDataFieldModelFactory
    {
        Task<List<DataFieldModel>> PrepareDataFieldModelList();
    }
}
