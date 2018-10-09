using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            OzellikTip = new HashSet<OzellikTip>();
            Urun = new HashSet<Urun>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int? ResimId { get; set; }

        public Resim Resim { get; set; }
        public ICollection<OzellikTip> OzellikTip { get; set; }
        public ICollection<Urun> Urun { get; set; }
    }
}
