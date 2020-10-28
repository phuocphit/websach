namespace _27_10.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBcontext : DbContext
    {
        public virtual DbSet<Sach> Sachs { get; set; }
        public virtual DbSet<LoaiSach> LoaiSachs { get; set; }
        public DBcontext()
            : base("name=DBcontext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
