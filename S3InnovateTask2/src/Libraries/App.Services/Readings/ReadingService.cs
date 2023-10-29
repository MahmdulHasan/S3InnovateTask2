using App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Readings
{
    public class ReadingService : IReadingService
    {
        private readonly IQueryRepository _repository;

        public ReadingService(IQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Reading>> GetReadingDataAsync(int buildingId = 0, int objectId = 0, int dataFieldId = 0, DateTime? startDate = null, DateTime? endDate = null)
        {

            var readingData =  _repository.Query<Reading>();

            if (buildingId != 0)
                readingData = readingData.Where(w => w.BuildingId == buildingId);
            
            if (objectId != 0)
                readingData = readingData.Where(w => w.BuildingId == objectId);
            
            if (dataFieldId != 0)
                readingData = readingData.Where(w => w.BuildingId == dataFieldId);

            if (startDate.HasValue)
                readingData = readingData.Where(w => w.Timestamp >= startDate);

            if (endDate.HasValue)
                readingData = readingData.Where(w => w.Timestamp <= endDate);

            return readingData;

        }
    }
}
