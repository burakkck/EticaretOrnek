using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZeonTicaret.WebUI.Models
{
    public partial class EticaretContext : DbContext
    {
        public EticaretContext()
        {
        }

        public EticaretContext(DbContextOptions<EticaretContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspnetApplications> AspnetApplications { get; set; }
        public virtual DbSet<AspnetPaths> AspnetPaths { get; set; }
        public virtual DbSet<AspnetPersonalizationAllUsers> AspnetPersonalizationAllUsers { get; set; }
        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
        public virtual DbSet<AspnetProfile> AspnetProfile { get; set; }
        public virtual DbSet<AspnetRoles> AspnetRoles { get; set; }
        public virtual DbSet<AspnetSchemaVersions> AspnetSchemaVersions { get; set; }
        public virtual DbSet<AspnetUsers> AspnetUsers { get; set; }
        public virtual DbSet<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        public virtual DbSet<AspnetWebEventEvents> AspnetWebEventEvents { get; set; }
        public virtual DbSet<Kargo> Kargo { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<MusteriAdres> MusteriAdres { get; set; }
        public virtual DbSet<OzellikDeger> OzellikDeger { get; set; }
        public virtual DbSet<OzellikTip> OzellikTip { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<SatisDetay> SatisDetay { get; set; }
        public virtual DbSet<SiparisDurum> SiparisDurum { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<UrunOzellik> UrunOzellik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=eTicaret;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspnetApplications>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Applications");

                entity.HasIndex(e => e.ApplicationName)
                    .HasName("UQ__aspnet_A__30910331B875DBFD")
                    .IsUnique();

                entity.HasIndex(e => e.LoweredApplicationName)
                    .HasName("aspnet_Applications_Index")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetPaths>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Paths");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath })
                    .HasName("aspnet_Paths_index")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LoweredPath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetPaths)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pa__Appli__03F0984C");
            });

            modelBuilder.Entity<AspnetPersonalizationAllUsers>(entity =>
            {
                entity.HasKey(e => e.PathId);

                entity.ToTable("aspnet_PersonalizationAllUsers");

                entity.Property(e => e.PathId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnType("image");

                entity.HasOne(d => d.Path)
                    .WithOne(p => p.AspnetPersonalizationAllUsers)
                    .HasForeignKey<AspnetPersonalizationAllUsers>(d => d.PathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pe__PathI__09A971A2");
            });

            modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_PersonalizationPerUser");

                entity.HasIndex(e => new { e.PathId, e.UserId })
                    .HasName("aspnet_PersonalizationPerUser_index1")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.UserId, e.PathId })
                    .HasName("aspnet_PersonalizationPerUser_ncindex2")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnType("image");

                entity.HasOne(d => d.Path)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.PathId)
                    .HasConstraintName("FK__aspnet_Pe__PathI__0D7A0286");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__aspnet_Pe__UserI__0E6E26BF");
            });

            modelBuilder.Entity<AspnetProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("aspnet_Profile");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PropertyNames)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.PropertyValuesBinary)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.PropertyValuesString)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetProfile)
                    .HasForeignKey<AspnetProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pr__UserI__6754599E");
            });

            modelBuilder.Entity<AspnetRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Roles");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName })
                    .HasName("aspnet_Roles_index1")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetRoles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Ro__Appli__70DDC3D8");
            });

            modelBuilder.Entity<AspnetSchemaVersions>(entity =>
            {
                entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion });

                entity.ToTable("aspnet_SchemaVersions");

                entity.Property(e => e.Feature).HasMaxLength(128);

                entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
            });

            modelBuilder.Entity<AspnetUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Users");

                entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate })
                    .HasName("aspnet_Users_Index2");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName })
                    .HasName("aspnet_Users_Index")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetUsers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__Appli__4222D4EF");
            });

            modelBuilder.Entity<AspnetUsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("aspnet_UsersInRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("aspnet_UsersInRoles_index");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__RoleI__75A278F5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__UserI__74AE54BC");
            });

            modelBuilder.Entity<AspnetWebEventEvents>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("aspnet_WebEvent_Events");

                entity.Property(e => e.EventId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplicationPath).HasMaxLength(256);

                entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);

                entity.Property(e => e.Details).HasColumnType("ntext");

                entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ExceptionType).HasMaxLength(256);

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Message).HasMaxLength(1024);

                entity.Property(e => e.RequestUrl).HasMaxLength(1024);
            });

            modelBuilder.Entity<Kargo>(entity =>
            {
                entity.Property(e => e.Adres).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(50);

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.WebSite).HasMaxLength(50);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResimId).HasColumnName("ResimID");

                entity.HasOne(d => d.Resim)
                    .WithMany(p => p.Kategori)
                    .HasForeignKey(d => d.ResimId)
                    .HasConstraintName("FK_Kategori_Resim");
            });

            modelBuilder.Entity<Marka>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResimId).HasColumnName("ResimID");

                entity.HasOne(d => d.Resim)
                    .WithMany(p => p.Marka)
                    .HasForeignKey(d => d.ResimId)
                    .HasConstraintName("FK_Marka_Resim");
            });

            modelBuilder.Entity<Musteri>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.Property(e => e.Cinsiyet).HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(50);

                entity.Property(e => e.KullaniciAdi).HasMaxLength(50);

                entity.Property(e => e.Soyadi).HasMaxLength(50);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Musteri)
                    .HasForeignKey<Musteri>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Musteri_aspnet_Users");
            });

            modelBuilder.Entity<MusteriAdres>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MusteriId).HasColumnName("MusteriID");

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.MusteriAdres)
                    .HasForeignKey(d => d.MusteriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MusteriAdres_Musteri");
            });

            modelBuilder.Entity<OzellikDeger>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OzellikTipId).HasColumnName("OzellikTipID");

                entity.HasOne(d => d.OzellikTip)
                    .WithMany(p => p.OzellikDeger)
                    .HasForeignKey(d => d.OzellikTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OzellikDeger_OzellikTip");
            });

            modelBuilder.Entity<OzellikTip>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.OzellikTip)
                    .HasForeignKey(d => d.KategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OzellikTip_Kategori");
            });

            modelBuilder.Entity<Resim>(entity =>
            {
                entity.Property(e => e.BuyukYol).HasMaxLength(250);

                entity.Property(e => e.KucukYol).HasMaxLength(250);

                entity.Property(e => e.OrtaYol).HasMaxLength(250);

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.Resim)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_Resim_Urun");
            });

            modelBuilder.Entity<Satis>(entity =>
            {
                entity.Property(e => e.KargoId).HasColumnName("KargoID");

                entity.Property(e => e.KargoTakipNo).HasMaxLength(20);

                entity.Property(e => e.MusteriId).HasColumnName("MusteriID");

                entity.Property(e => e.SatisTarihi)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SepetteMi)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SiparisDurumId).HasColumnName("SiparisDurumID");

                entity.Property(e => e.ToplamTutar).HasColumnType("money");

                entity.HasOne(d => d.Kargo)
                    .WithMany(p => p.Satis)
                    .HasForeignKey(d => d.KargoId)
                    .HasConstraintName("FK_Satis_Kargo");

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.Satis)
                    .HasForeignKey(d => d.MusteriId)
                    .HasConstraintName("FK_Satis_Musteri");

                entity.HasOne(d => d.SiparisDurum)
                    .WithMany(p => p.Satis)
                    .HasForeignKey(d => d.SiparisDurumId)
                    .HasConstraintName("FK_Satis_SiparisDurum");
            });

            modelBuilder.Entity<SatisDetay>(entity =>
            {
                entity.HasKey(e => new { e.SatisId, e.UrunId });

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.Fiyat).HasColumnType("money");

                entity.HasOne(d => d.Satis)
                    .WithMany(p => p.SatisDetay)
                    .HasForeignKey(d => d.SatisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SatisDetay_Satis");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SatisDetay)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SatisDetay_Urun");
            });

            modelBuilder.Entity<SiparisDurum>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AlisFiyat).HasColumnType("money");

                entity.Property(e => e.EklenmeTarihi)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.MarkaId).HasColumnName("MarkaID");

                entity.Property(e => e.SatisFiyat).HasColumnType("money");

                entity.Property(e => e.SonKullanmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Urun)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Urun_Kategori");

                entity.HasOne(d => d.Marka)
                    .WithMany(p => p.Urun)
                    .HasForeignKey(d => d.MarkaId)
                    .HasConstraintName("FK_Urun_Marka");
            });

            modelBuilder.Entity<UrunOzellik>(entity =>
            {
                entity.HasKey(e => new { e.UrunId, e.OzellikTipId, e.OzellikDegerId });

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.OzellikTipId).HasColumnName("OzellikTipID");

                entity.Property(e => e.OzellikDegerId).HasColumnName("OzellikDegerID");

                entity.HasOne(d => d.OzellikDeger)
                    .WithMany(p => p.UrunOzellik)
                    .HasForeignKey(d => d.OzellikDegerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunOzellik_OzellikDeger");

                entity.HasOne(d => d.OzellikTip)
                    .WithMany(p => p.UrunOzellik)
                    .HasForeignKey(d => d.OzellikTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunOzellik_OzellikTip");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.UrunOzellik)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunOzellik_Urun");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
