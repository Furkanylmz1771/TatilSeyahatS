using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TatilVeSeyahatSitesi.Models.Siniflar
{
    public class Context : DbContext             // Data ile ilişkilendirme kısmı 
    {
        public DbSet<Admin> Admins { get; set; }    // Admin sınıfının database karşılıği Admins
        public DbSet<AdresBlog> AdresBlogs { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Hakkimizda> Hakkimizdas { get; set; }

        public DbSet<İletisim> İletisims { get; set; }

        public DbSet<Yorumlar> Yorumlars { get; set; }

    }
}