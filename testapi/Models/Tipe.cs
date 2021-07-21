using System;
using System.Collections.Generic;

namespace testapi.Models
{
    public class Tipe
    {
        public Tipe()
        {
            Shops = new HashSet<Shop>();
        }

        public short IdType { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public ICollection<Shop> Shops { get; set; }
    }
}
