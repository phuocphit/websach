namespace LTQL23_10.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBconnect : DbContext
    {
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Loaisach> Loaisaches { get; set; }
        public DBconnect()
            : base("name=DBconnect")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
