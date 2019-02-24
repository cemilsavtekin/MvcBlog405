using MvcBlog.Entities.Concrete.Account;
using MvcBlog.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.DataAccess.Concrete.EntitiyFramework
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("BlogDB")
        {

        }

        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Resim> Resimler { get; set; }
        public DbSet<ResimTip> ResimTipler { get; set; }
        public DbSet<Role> Roller { get; set; }
        public DbSet<User> Kullanicilar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
    }
}
