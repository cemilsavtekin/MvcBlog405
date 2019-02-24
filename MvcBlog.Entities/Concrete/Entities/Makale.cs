using MvcBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Entities.Concrete.Entities
{
    [Table("Makaleler")]
    public class Makale: IEntity
    {
        public int MakaleID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YayinTarihi { get; set; }
        
        public int KategoriID { get; set; }
        [ForeignKey("KategoriID")]
        public Kategori Kategori { get; set; }

        public int YazarID { get; set; }
        [ForeignKey("YazarID")]
        public Yazar Yazar { get; set; }

        public List<Yorum> Yorumlar { get; set; }

        public List<Etiket> Etiketler { get; set; }
    }
}
