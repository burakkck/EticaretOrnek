using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class OzellikTip
    {
        public OzellikTip()
        {
            OzellikDeger = new HashSet<OzellikDeger>();
            UrunOzellik = new HashSet<UrunOzellik>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int KategoriId { get; set; }

        public Kategori Kategori { get; set; }
        public ICollection<OzellikDeger> OzellikDeger { get; set; }
        public ICollection<UrunOzellik> UrunOzellik { get; set; }
    }
}
