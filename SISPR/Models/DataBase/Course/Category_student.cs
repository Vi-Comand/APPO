using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Course
{
    public class Category_student
    {[Key]
        public int category_student_id { get; set; }
        public string name { get; set; }
    }
}
