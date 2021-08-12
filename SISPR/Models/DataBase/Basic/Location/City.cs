using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace SISPR.Models.DataBase.Basic.Location

{
    public class City
    {
        public int city_id { get; set; }
        public string name { get; set; }
        public int mo_id { get; set; }
        public string fias_code { get; set; }
        public string search_name { get; set; }

        
       


    }
}
