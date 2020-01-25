using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticlesApp.Models
{
    public class Article
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название статьи")]
        [Required(ErrorMessage ="Пожалуйста, укажите название статьи")]
        public string Name { get; set; }

        [Display(Name = "Короткое описание")]
        public string ShortDescription { get; set; }

        [Display(Name = "Текст статьи")]
        [Required(ErrorMessage = "Пожалуйста, укажите текст статьи")]
        public string Description { get; set; }

        [Display(Name = "Изображение")]
        public string HeroImage { get; set; }
        public byte[] ImageData { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию статьи")]
        public string Category { get; set; }

        [Display(Name = "Теги")]
        public string Tags { get; set; }
    }
}