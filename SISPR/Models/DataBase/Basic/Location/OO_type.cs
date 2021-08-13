using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Basic.Location
{
    public class OO_type
    {
        [Key]
        public int oo_type_id { get; set; }
        public string name { get; set; }
    }
}
