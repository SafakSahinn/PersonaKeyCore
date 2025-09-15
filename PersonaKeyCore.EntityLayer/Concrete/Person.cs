using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaKeyCore.EntityLayer.Concrete
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int RoleId { get; set; } // Yeni eklenen kısım
        public Role Role { get; set; }  // Yeni eklenen kısım

        public List<Card> Cards { get; set; }
        public List<AccessLog> AccessLogs { get; set; }
    }
}
