using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class Resim
    {
        public Resim()
        {
            Kategori = new HashSet<Kategori>();
            Marka = new HashSet<Marka>();
        }

        public int Id { get; set; }
        public string BuyukYol { get; set; }
        public string OrtaYol { get; set; }
        public string KucukYol { get; set; }
        public bool? Varsayilan { get; set; }
        public byte? SiraNo { get; set; }
        public int? UrunId { get; set; }

        public Urun Urun { get; set; }
        public ICollection<Kategori> Kategori { get; set; }
        public ICollection<Marka> Marka { get; set; }
    }
}
