using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class Urun
    {
        public Urun()
        {
            Resim = new HashSet<Resim>();
            SatisDetay = new HashSet<SatisDetay>();
            UrunOzellik = new HashSet<UrunOzellik>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public DateTime? SonKullanmaTarihi { get; set; }
        public int? KategoriId { get; set; }
        public int? MarkaId { get; set; }

        public Kategori Kategori { get; set; }
        public Marka Marka { get; set; }
        public ICollection<Resim> Resim { get; set; }
        public ICollection<SatisDetay> SatisDetay { get; set; }
        public ICollection<UrunOzellik> UrunOzellik { get; set; }
    }
}
