using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Course
{
    public class Course
    {
        [Key]
        public int course_id { get; set; }
        public string dpp_pk { get; set; }
        public  string tema { get; set; }
        public bool pp_pkp { get; set; }
        public int mesto_providenia { get; set; }
        public int kol_hour { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public int kvota { get; set; }
        public int kol_group { get; set; }
        public int kol_pod_group { get; set; }
        public int kol_sluhatel { get; set; }
        public bool budjet_vnebudjet { get; set; }
        public int rukovoditel_user_id { get; set; }
        public int utp_id { get; set; }
        public int kafedra_id { get; set; }
        public string opisanie { get; set; }

    }
}
