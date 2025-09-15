using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PersonaKeyCore.EntityLayer.Concrete
{
    public class AppUser : IdentityUser
    {
        // İhtiyacınız olursa, kullanıcıya özgü ek alanları buraya ekleyebilirsiniz.
        // Örneğin:
        // public string FullName { get; set; }
        // public string Department { get; set; }
    }
}
