using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Entities.Concrete.Entities
{
    [Table("Yazarlar")]
    public class Yazar
    {
        public int YazarID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Unvan { get; set; }
        public string CalistigiKurum { get; set; }
        public string Hakkinda { get; set; }

        public List<Makale> Makaleler { get; set; }
    }
}
