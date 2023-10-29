using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Readings
{
    public interface IReadingService
    {
        Task<IQueryable<Reading>> GetReadingDataAsync(int buildingId=0, int objectId=0, int dataFieldId=0, DateTime? startDate = null, DateTime? endDate = null);
    }
}
