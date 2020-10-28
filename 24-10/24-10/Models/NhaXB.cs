namespace _24_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaXB")]
    public partial class NhaXB
    {
        [Key]
        [StringLength(50)]
        public string MaNXB { get; set; }

        [StringLength(50)]
        public string TenNXB { get; set; }

        [StringLength(50)]
        public string MaSach { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
