using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class Satis
    {
        public Satis()
        {
            SatisDetay = new HashSet<SatisDetay>();
        }

        public int Id { get; set; }
        public Guid? MusteriId { get; set; }
        public DateTime SatisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool? SepetteMi { get; set; }
        public int? KargoId { get; set; }
        public int? SiparisDurumId { get; set; }
        public string KargoTakipNo { get; set; }

        public Kargo Kargo { get; set; }
        public Musteri Musteri { get; set; }
        public SiparisDurum SiparisDurum { get; set; }
        public ICollection<SatisDetay> SatisDetay { get; set; }
    }
}
