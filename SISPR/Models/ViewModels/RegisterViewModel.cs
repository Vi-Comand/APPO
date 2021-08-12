using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SISPR.Models.DataBase.Basic.Location;

namespace SISPR.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Фамилия")]
        public string F { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string I { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string O { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "СНИЛС")]
        public string SNILS { get; set; }

        public City City { get; set; } = new City();
        public MO MO { get; set; } = new MO();
        public OO OO { get; set; } = new OO();
        public Region Region { get; set; } = new Region();



    }
}
