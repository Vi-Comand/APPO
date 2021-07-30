using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Course
{
    public class Course_category_student
    {
        [Key]
        public int course_category_stident_id { get; set; }
        public int course_id { get; set; }
        public int category_stident_id { get; set; }
    }
}
