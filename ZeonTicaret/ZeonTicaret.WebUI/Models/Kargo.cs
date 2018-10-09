using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class Kargo
    {
        public Kargo()
        {
            Satis = new HashSet<Satis>();
        }

        public int Id { get; set; }
        public string SirketAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }

        public ICollection<Satis> Satis { get; set; }
    }
}
