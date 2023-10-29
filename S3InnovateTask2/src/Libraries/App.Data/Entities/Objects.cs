using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Objects : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Reading> Readings { get; set; }
    }
}
