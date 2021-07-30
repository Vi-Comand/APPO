using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Course
{
    public class Subgroup
    {
        [Key]
        public int subgroup_id { get; set; }
        public string name { get; set; }
        public int kol_student { get; set; }
        public int group_id { get; set; }

    }
}
