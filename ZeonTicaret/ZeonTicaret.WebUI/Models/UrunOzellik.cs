using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class UrunOzellik
    {
        public int UrunId { get; set; }
        public int OzellikTipId { get; set; }
        public int OzellikDegerId { get; set; }

        public OzellikDeger OzellikDeger { get; set; }
        public OzellikTip OzellikTip { get; set; }
        public Urun Urun { get; set; }
    }
}
