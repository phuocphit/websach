using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSach.Models
{
    [Table("HoaDons")]
    public class HoaDon
    {
        [Key]
        [MaxLength(50)]
        public string MaHoaDon { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DateTime NgayHoaDon { get; set; }
        [MaxLength(50)]
        public string TinhTrang { get; set; }
        public int TongGiaTri { get; set; }
        [MaxLength(50)]
        public string DiaChi { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [ForeignKey("Email")]
        public User User { get; set; }
    }
}