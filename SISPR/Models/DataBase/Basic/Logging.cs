using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Basic
{
    public class Logging
    {
        public int logging_id { get; set; }
        public int user_id { get; set; }
        public string table_name { get; set; }
        public DateTime date_create { get; set; }
        public DateTime date_modify { get; set; }
        public int id { get; set; }
    }
}
