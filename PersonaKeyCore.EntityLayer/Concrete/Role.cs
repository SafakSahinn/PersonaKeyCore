using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaKeyCore.EntityLayer.Concrete
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // "Bilgi İşlem", "Muhasebe" gibi

        public List<Person> Persons { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
