using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.UTP
{
    public class UTP_type_training_load
    {
        [Key]
        public int utp_type_training_load_id { get; set; }
       public int utp_id { get; set; }
       public int type_training_load_id { get; set; }

    }
}
