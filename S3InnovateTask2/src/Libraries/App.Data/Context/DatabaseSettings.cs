using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
    public class DatabaseSettings
    {
        public string ApplicationConnectionString { get; set; } = string.Empty;
        public bool UseLazyLoading { get; set; }
        public int CommandTimeOutInSecond { get; set; }
    }
}
