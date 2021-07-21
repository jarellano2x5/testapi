using System;
using System.Collections.Generic;

namespace testapi.Models
{
    public class Country
    {
        public Country()
        {
            Shops = new HashSet<Shop>();
            Tariffies = new HashSet<Tariff>();
        }

        public short IdCountry { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Acronym { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Tariff> Tariffies { get; set; }
    }
}
