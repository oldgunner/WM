using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticlesApp.Models
{
    public class AdminLogin
    {
        [Required]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 50 символов")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class AdminRegister
    {
        [Required]
        [Display(Name ="Введите имя")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 50 символов")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Введите электронную почту")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        [RegularExpression(@"^(?=.{2,}[a-zA-Z])(?=.{2,}[0-9])(?=.{2,}[#?!@$%^&*-]).{8,}$", ErrorMessage = "Пароль должен содержать не менее 8 знаков," +
            "из них 2 цифры, 2 буквы латинского алфавита и 2 специальных символа")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Введите возраст")]
        [Range(18, 100,ErrorMessage ="Введите правильный возраст")]
        public int Age { get; set; }
    }
}