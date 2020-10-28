namespace _24_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            NhaXBs = new HashSet<NhaXB>();
        }

        [Key]
        [StringLength(50)]
        public string MaSach { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [StringLength(50)]
        public string MaLoaiSach { get; set; }

        public DateTime? NgayXuatBan { get; set; }

        public int? GiaSach { get; set; }

        [StringLength(50)]
        public string MaTacGia { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhaXB> NhaXBs { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
