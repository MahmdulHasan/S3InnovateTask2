using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Framework.Models
{
    public class ReadingModel
    {
        public decimal Value { get; set; }
        public string Timestamp { get; set; } = string.Empty;
    }
}
