using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.UTP
{
    public class UTP
    {
        [Key]
        public int utp_id { get; set; }
        public string name { get; set; }
        public float hour { get; set; }
        public int kol_groups { get; set; }
        public int kol_slushatel_v_group { get; set; }
        public int kol_subgroups { get; set; }
        public int rejim_zanyati { get; set; }
        public int forma_obuchen_id { get; set; }


    }
}
