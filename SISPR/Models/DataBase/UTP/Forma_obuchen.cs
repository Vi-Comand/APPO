using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.UTP
{
    public class Forma_obuchen
    {
        [Key]
        public int forma_obuchen_id { get; set; }
        public string name { get; set; }

    }
}
