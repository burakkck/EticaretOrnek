using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class MusteriAdres
    {
        public int Id { get; set; }
        public Guid MusteriId { get; set; }
        public string Adres { get; set; }
        public string Adi { get; set; }

        public Musteri Musteri { get; set; }
    }
}
