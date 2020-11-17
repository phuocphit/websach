using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSach.Models
{
    [Table("GioHangs")]
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }
        [MaxLength(50)]
        public string MaSach { get; set; }
        [ForeignKey("MaSach")]
        public Sach Sach { get; set; }
        [MaxLength(50)]
        public string TenSach { get; set; }
        public int SoLuongMua { get; set; }
        public int GiaBan { get; set; }
        [MaxLength(50)]
        public string MaGiaoDIch { get; set; }
    }
}