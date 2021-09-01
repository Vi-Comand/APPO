using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SISPR.Models.DataBase.Basic.Location ;
using SISPR.Models.DataBase.UTP;
using SISPR.Models.DataBase.Course;
using SISPR.Models.DataBase.Basic.User;
using SISPR.Models.DataBase.Basic.Dictionary;

namespace SISPR.Models.ViewModels
{
    public class AddCourseViewModel
    {
        [Required]
        [Display(Name = "УТП")]
        public int utp_id { get; set; }
        public List<UTP> ListUtp { get; set; } = new List<UTP>();

        [Required]
        [Display(Name = "Форма обучения")]
        public bool budjet_vnebudjet { get; set; }
        
        [Required]
        [Display(Name = "Переподготовка/Повышение квалификации")]
        public bool pp_pkp { get; set; }

        [Required]
        [Display(Name = "Дата начала")]
        public DateTime date_start { get; set; }

        [Required]
        [Display(Name = "Дата окончания")]
        public DateTime date_end { get; set; }

        [Required]
        [Display(Name = "Реализация ДПП ПК")]
        public string dpp_pk { get; set; }

        [Required]
        [Display(Name = "Тема курсов")]
        public string tema { get; set; }

        [Required]
        [Display(Name = "Обьем курсов")]
        public int kol_hour { get; set; }

        public City City { get; set; } = new City();
        
        [Required]
        [Display(Name = "Квота")]
        public int kvota { get; set; }

        [Required]
        [Display(Name = "Количество групп")]
        public int kol_group { get; set; }

        [Required]
        [Display(Name = "Количество подгрупп")]
        public int kol_pod_group { get; set; }

        [Required]
        [Display(Name = "Количество слушателей в группе")]
        public int kol_sluhatel { get; set; }

        [Required]
        [Display(Name = "Руководитель курса")]
        public int rukovoditel_user_id { get; set; }

        [Required]
        [Display(Name = "Кафедра")]
        public int kafedra_id { get; set; }

       
        [Display(Name = "Описание курсов")]
        public string opisanie { get; set; }

        public MO MO { get; set; } = new MO();
        public OO OO { get; set; } = new OO();
        public Region Region { get; set; } = new Region();
        public Group Group { get; set; } = new Group();
        public Subgroup Subgroup { get; set; } = new Subgroup();
        public Category_student Category_student { get; set; } = new Category_student();
        public User User { get; set; } = new User();
        public Kafedra Kafedra { get; set; } = new Kafedra();

    }
}
