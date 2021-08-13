using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SISPR.Models.DataBase.Basic.User
{
    public class User:IdentityUser
    {
        [ForeignKey("id_us")]
        public int user_id { get; set; }
        public string f { get; set; }
        public string i { get; set; }
        public string o { get; set; }
        public ulong snils  { get; set; }
    
        
      
        public int mo_id { get; set; }
        public int region_id { get; set; }
        public int city_id { get; set; }
        public int oo_id { get; set; }


    }
}
