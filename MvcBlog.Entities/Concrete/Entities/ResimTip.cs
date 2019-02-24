using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Entities.Concrete.Entities
{
    [Table("ResimTipleri")]
    public class ResimTip
    {
        public int ResimTipID { get; set; }
        public string ResimTipi { get; set; }

        public List<Resim> Resimler { get; set; }
    }
}