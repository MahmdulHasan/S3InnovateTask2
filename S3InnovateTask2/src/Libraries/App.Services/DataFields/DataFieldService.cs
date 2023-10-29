using App.Services.DateFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.DataFields
{
    public class DataFieldService : IDataFieldService
    {
        private readonly IQueryRepository _repository;

        public DataFieldService(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DataField>> GetDataFieldsAsync()
        {
            var dataFields = await _repository.Query<DataField>().ToListAsync();

            return dataFields;
        }
    }
}
