using MvcBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Entities.Concrete.Entities
{
    [Table("Resimler")]
    public class Resim: IEntity
    {
        public int ResimID { get; set; }
        public string ResimUrl { get; set; }

        public int ResimTipID { get; set; }
        [ForeignKey("ResimTipID")]
        public ResimTip ResimTip { get; set; }

        public int MakaleID { get; set; }
        [ForeignKey("MakaleID")]
        public Makale Makale { get; set; }


    }
}
