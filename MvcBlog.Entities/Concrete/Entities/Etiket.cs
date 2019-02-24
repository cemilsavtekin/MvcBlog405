using MvcBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Entities.Concrete.Entities
{
    [Table("Etiketler")]
    public class Etiket: IEntity
    {
        public int EtiketID { get; set; }
        public string EtiketAdi { get; set; }

        public List<Makale> Makaleler { get; set; }
    }
}
