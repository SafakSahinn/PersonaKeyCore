using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaKeyCore.EntityLayer.Concrete
{
    public class AccessLog
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int DoorId { get; set; }
        public Door Door { get; set; }
        public DateTime AccessTime { get; set; }
        public string Status { get; set; } // "Granted", "Denied" gibi
    }
}
