﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Basic.Location

{
    public class MO
    {
        [Key]
        public int mo_id { get; set; }
        public string fias_code { get; set; }
        public string searсh_name { get; set; }
        public string name { get; set; }
     
        public int region_id { get; set; }
    }
}
