using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class Marka
    {
        public Marka()
        {
            Urun = new HashSet<Urun>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int? ResimId { get; set; }

        public Resim Resim { get; set; }
        public ICollection<Urun> Urun { get; set; }
    }
}
