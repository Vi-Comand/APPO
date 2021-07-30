using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.UTP
{
    public class Type_training_load
    {
        [Key]
        public int type_training_load_id { get; set; }
        public string name { get; set; }
        public float number_hours { get; set; }
        public float number_groups { get; set; }
        public float number_subgroups { get; set; }
        public float number_control_forms { get; set; }
        public float number_listeners { get; set; }
        public float volume_hours { get; set; }
        public int type { get; set; }

    }
}
