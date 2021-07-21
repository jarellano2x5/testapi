using System;
namespace testapi.DTOs
{
    public class TariffDTO
    {
        public short IdTariff { get; set; }
        public string Initial { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public short IdCountry { get; set; }
    }
}
