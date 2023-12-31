﻿
using App.Services.Readings;

namespace App.Web.Framework.Factories
{
    public class ReadingModelFactory : IReadingModelFactory
    {
        private readonly IReadingService _readingService;

        public ReadingModelFactory(IReadingService readingService)
        {
            _readingService = readingService;
        }
        public async Task<List<ReadingModel>> GetTimeSeriesData(int buildingId = 0, int objectId = 0, int dataFieldId = 0, DateTime? startDate = null, DateTime? endDate = null)
        {
            var readings = await _readingService.GetReadingDataAsync(buildingId, objectId,
                               dataFieldId, startDate, endDate);

            var groupedreadingData = readings
                                             .OrderBy(g => g.Timestamp)
                                             .Select(s => new ReadingModel
                                             {
                                                 Timestamp = s.Timestamp,
                                                 Value =  s.Value
                                             }).ToList();

            return groupedreadingData;
        }
    }
}
