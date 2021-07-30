using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Course
{
    public class Group
    {
        [Key]
        public int group_id { get; set; }
        public string name { get; set; }
        public int kol_subgroup { get; set; }
        public int course_id { get; set; }
        public int kol_student { get; set; }

    }
}
