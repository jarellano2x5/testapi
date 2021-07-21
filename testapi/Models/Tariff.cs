using System;
namespace testapi.Models
{
    public class Tariff
    {
        public short IdTariff { get; set; }
        public string Initial { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public short IdCountry { get; set; }

        // public virtual Country Country { get; set; }
    }
}
