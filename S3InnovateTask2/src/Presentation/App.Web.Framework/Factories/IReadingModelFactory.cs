

namespace App.Web.Framework.Factories
{
    public interface IReadingModelFactory
    {
        Task<List<ReadingModel>> GetTimeSeriesData(int buildingId = 0, int objectId = 0, int dataFieldId = 0, DateTime? startDate = null, DateTime? endDate = null);
    }
}
