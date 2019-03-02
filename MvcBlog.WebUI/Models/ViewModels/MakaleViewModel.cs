using MvcBlog.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog.WebUI.Models.ViewModels
{
    public class MakaleViewModel
    {
        public int MakaleID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int YazarID { get; set; }
        public string AdSoyad { get; set; }
        public int KategoriID { get; set; }
        public string Kategori { get; set; }


    }
}