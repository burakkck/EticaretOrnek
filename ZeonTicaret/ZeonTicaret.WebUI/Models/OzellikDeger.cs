using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class OzellikDeger
    {
        public OzellikDeger()
        {
            UrunOzellik = new HashSet<UrunOzellik>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int OzellikTipId { get; set; }

        public OzellikTip OzellikTip { get; set; }
        public ICollection<UrunOzellik> UrunOzellik { get; set; }
    }
}
