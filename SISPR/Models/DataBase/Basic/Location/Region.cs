using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Basic.Location
{
    public class Region
    {
        public int region_id { get; set; }
        public double fias_code { get; set; }
        public string name { get; set; }
        public string search_name { get; set; }
        public int code { get; set; }
    }
}
