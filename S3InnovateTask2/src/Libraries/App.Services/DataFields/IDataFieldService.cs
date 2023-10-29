using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.DateFields
{
    public interface IDataFieldService
    {
        Task<List<DataField>> GetDataFieldsAsync();
    }
}
