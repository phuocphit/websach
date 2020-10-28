namespace _25_10.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBcontext : DbContext
    {
        public virtual DbSet<sach> sachs { get; set; }
        public virtual DbSet<loaisach> loaisachs { get; set; }
        public DBcontext()
            : base("name=DBcontext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
