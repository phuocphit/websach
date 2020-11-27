namespace websachs.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBcontext : DbContext
    {
        public DBcontext()
            : base("name=DBcontext")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiSach> LoaiSachs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Sachs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSach>()
                .Property(e => e.MaLoaiSach)
                .IsUnicode(false);
            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.MaNXB)
                .IsUnicode(false);
            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);
            modelBuilder.Entity<GioHang>()
                .Property(e => e.MaGiaoDIch)
                .IsUnicode(false);
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);
            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);
            modelBuilder.Entity<User>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

        }
    }
}
