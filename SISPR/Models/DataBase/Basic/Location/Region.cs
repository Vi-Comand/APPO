using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Basic.Location
{
    public class Region
    {
        [Key]
        public int region_id { get; set; }
        public string fias_code { get; set; }
        public string name { get; set; }
        public string search_name { get; set; }
        public int code { get; set; }
    }
}
