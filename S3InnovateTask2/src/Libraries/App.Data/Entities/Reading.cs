using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Reading
    {
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public decimal Value { get; set; }
        public DateTime Timestamp { get; set; }

        public Building Building { get; set; }
        public Objects Objects { get; set; }
        public DataField DataField { get; set; }
    }
}
