using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class SiparisDurum
    {
        public SiparisDurum()
        {
            Satis = new HashSet<Satis>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }

        public ICollection<Satis> Satis { get; set; }
    }
}
