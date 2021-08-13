using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Basic.Location
{
    public class OO
    {
        [Key]
        public int oo_id { get; set; }
        public string name { get; set; }
        public string name_short { get; set; }
        public int city_id { get; set; }
        public string inn { get; set; }
    }
}
