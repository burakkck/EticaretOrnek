using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class Musteri
    {
        public Musteri()
        {
            MusteriAdres = new HashSet<MusteriAdres>();
            Satis = new HashSet<Satis>();
        }

        public Guid Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Cinsiyet { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public AspnetUsers IdNavigation { get; set; }
        public ICollection<MusteriAdres> MusteriAdres { get; set; }
        public ICollection<Satis> Satis { get; set; }
    }
}
