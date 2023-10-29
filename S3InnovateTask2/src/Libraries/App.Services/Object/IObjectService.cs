using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Object
{
    public interface IObjectService
    {
        Task<List<Objects>> GetObjectsAsync();
    }
}
