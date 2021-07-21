using System;
namespace testapi.Models
{
    public class Shop
    {
        public int IdShop { get; set; }
        public string RFC { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Zip { get; set; }
        public string TagLine { get; set; }
        public short IdCountry { get; set; }
        public short IdType { get; set; }
        public short IdStatus { get; set; }

        public virtual Country Country { get; set; }
        public virtual Tipe Tipe { get; set; }
        public virtual Status Status { get; set; }
    }
}
