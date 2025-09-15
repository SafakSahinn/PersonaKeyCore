using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaKeyCore.EntityLayer.Concrete
{
    public class Card
    {
        public int Id { get; set; }
        public string CardCode { get; set; } // ESP32'den okunacak benzersiz kod
        public bool IsActive { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
