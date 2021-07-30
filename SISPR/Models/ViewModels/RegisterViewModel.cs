using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
    }
}
