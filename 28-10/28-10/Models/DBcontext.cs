namespace _28_10.Models
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
        public virtual DbSet<Sach> Sachs { get; set; }
        public virtual DbSet<LoaiSach> LoaiSachs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sach>()
                .Property(e => e.Masach)
                .IsUnicode(false);
            modelBuilder.Entity<Sach>()
                .Property(e => e.Matacgia)
                .IsUnicode(false);
            modelBuilder.Entity<LoaiSach>()
                .Property(e => e.Maloaisach)
                .IsUnicode(false);
        }
    }
}
