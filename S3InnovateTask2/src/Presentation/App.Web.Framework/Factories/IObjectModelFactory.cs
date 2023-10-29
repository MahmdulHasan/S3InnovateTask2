

namespace App.Web.Framework.Factories
{
    public interface IObjectModelFactory
    {
        Task<List<ObjectModel>> PrepareObjectModelList();
    }
}
