using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPR.Models.DataBase.Basic.User
{
    public class User_role
    {
        public int user_role_id { get; set; }
        public int user_id { get; set; }
        public int role_id { get; set; }
    }
}
