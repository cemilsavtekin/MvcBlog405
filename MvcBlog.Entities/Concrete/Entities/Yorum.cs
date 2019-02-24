using MvcBlog.Entities.Abstract;
using MvcBlog.Entities.Concrete.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Entities.Concrete.Entities
{
    [Table("Yorumlar")]
    public class Yorum: IEntity
    {
        public int YorumID { get; set; }
        public string Icerik { get; set; }
        public DateTime YorumTarihi { get; set; }
        public int UstYorumID { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        
        
    }
}
