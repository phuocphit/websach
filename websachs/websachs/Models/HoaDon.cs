using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace websachs.Models
{
    [Table("HoaDons")]
    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DateTime NgayHoaDon { get; set; }
        [MaxLength(50)]
        public string TinhTrang { get; set; }
        public int TongGiaTri { get; set; }
        [MaxLength(50)]
        public string DiaChi { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual User User { get; set; }

    }
}