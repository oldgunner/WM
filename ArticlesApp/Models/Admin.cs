using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Введите имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Введите электронную почту")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Введите возраст")]
        public int Age { get; set; }
    }
}