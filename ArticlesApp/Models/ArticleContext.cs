﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ArticlesApp.Models
{
    public class ArticleContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}