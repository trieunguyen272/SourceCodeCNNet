namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLKTXDbContext : DbContext
    {
        public QLKTXDbContext()
            : base("name=QLKTXDbContext")
        {
        }

        public virtual DbSet<DGDIEN> DGDIENs { get; set; }
        public virtual DbSet<DGNUOC> DGNUOCs { get; set; }
        public virtual DbSet<DIENNUOC> DIENNUOCs { get; set; }
        public virtual DbSet<HDDIENNUOC> HDDIENNUOCs { get; set; }
        public virtual DbSet<HOPDONG> HOPDONGs { get; set; }
        public virtual DbSet<KHUNHA> KHUNHAs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<QUANLY> QUANLies { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<THANNHAN> THANNHANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DGDIEN>()
                .HasMany(e => e.HDDIENNUOCs)
                .WithOptional(e => e.DGDIEN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DGNUOC>()
                .HasMany(e => e.HDDIENNUOCs)
                .WithOptional(e => e.DGNUOC)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DIENNUOC>()
                .Property(e => e.MAPHONG)
                .IsUnicode(false);

            modelBuilder.Entity<DIENNUOC>()
                .Property(e => e.MAQL)
                .IsUnicode(false);

            modelBuilder.Entity<HDDIENNUOC>()
                .Property(e => e.MAPHONG)
                .IsUnicode(false);

            modelBuilder.Entity<HDDIENNUOC>()
                .Property(e => e.MAQL)
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.MASV)
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.MAPHONG)
                .IsUnicode(false);

            modelBuilder.Entity<KHUNHA>()
                .Property(e => e.MAKHU)
                .IsUnicode(false);

            modelBuilder.Entity<KHUNHA>()
                .HasMany(e => e.PHONGs)
                .WithOptional(e => e.KHUNHA)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MAPHONG)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MAKHU)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.DIENNUOCs)
                .WithOptional(e => e.PHONG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.HDDIENNUOCs)
                .WithOptional(e => e.PHONG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.HOPDONGs)
                .WithOptional(e => e.PHONG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.MAQL)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLY>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLY>()
                .HasMany(e => e.DIENNUOCs)
                .WithOptional(e => e.QUANLY)
                .WillCascadeOnDelete();

            modelBuilder.Entity<QUANLY>()
                .HasMany(e => e.HDDIENNUOCs)
                .WithOptional(e => e.QUANLY)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.MASV)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.HOPDONGs)
                .WithOptional(e => e.SINHVIEN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.THANNHANs)
                .WithOptional(e => e.SINHVIEN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<THANNHAN>()
                .Property(e => e.MASV)
                .IsUnicode(false);

            modelBuilder.Entity<THANNHAN>()
                .Property(e => e.SDTCHA)
                .IsUnicode(false);

            modelBuilder.Entity<THANNHAN>()
                .Property(e => e.SDTME)
                .IsUnicode(false);
        }
    }
}
