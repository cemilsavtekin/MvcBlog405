using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Entities.Concrete.Account
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public List<User> Kullanicilar { get; set; }
    }
}
