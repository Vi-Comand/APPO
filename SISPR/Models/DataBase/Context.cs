using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SISPR.Controllers;
using SISPR.Models.DataBase.Basic.Location;
using SISPR.Models.DataBase.UTP;
using SISPR.Models.DataBase.Course;
using SISPR.Models.DataBase.Basic.User;
namespace SISPR.Models.DataBase
{
    public class Context:DbContext

    {
     //   public DbSet<User> User { get; set; }
    public DbSet<UTP.UTP> UTPs { get; set; }
    public DbSet<Type_training_load> Type_training_load { get; set; }
    public DbSet<UTP_type_training_load> UTP_type_training_load { get; set; }
    public DbSet<Category_student> Category_student { get; set; }
    public DbSet<Course.Course> Course { get; set; }
    public DbSet<Course_category_student> Course_category_student { get; set; }
    public DbSet<Group> Group { get; set; }
    public DbSet<Subgroup> Subgroup { get; set; }
    public DbSet<Region> Region { get; set; }
    public DbSet<MO> MO { get; set; }
    public DbSet<OO> OO { get; set; }

    public DbSet<City> City { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
    {
        //Database.EnsureCreated();

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    }
}
