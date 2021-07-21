using System;
using System.Collections.Generic;

namespace testapi.Models
{
    public class Status
    {
        public Status()
        {
            Shops = new HashSet<Shop>();
        }

        public short IdStatus { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
