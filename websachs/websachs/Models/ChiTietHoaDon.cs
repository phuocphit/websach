using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace websachs.Models
{
    [Table("ChiTietHoaDons")]
    public class ChiTietHoaDon
    {
        [Key]
        public int id { get; set; }
        public int MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]
        public HoaDon HoaDon { get; set; }
        [MaxLength(50)]
        public string MaSach { get; set; }
        [ForeignKey("MaSach")]
        public Sach Sach { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }
}