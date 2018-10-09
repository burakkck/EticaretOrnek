using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class SatisDetay
    {
        public int SatisId { get; set; }
        public int UrunId { get; set; }
        public int? Adet { get; set; }
        public decimal? Fiyat { get; set; }
        public double? Indirim { get; set; }

        public Satis Satis { get; set; }
        public Urun Urun { get; set; }
    }
}
