using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSach.Models
{
    [Table("Sachs")]
    public class Sach
    {
        [Key]
        [MaxLength(50)]
        public string MaSach { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }
        [MaxLength(50)]
        public string TenSach { get; set; }
        [MaxLength(50)]
        public string MaLoaiSach { get; set; }
        [ForeignKey("MaLoaiSach")]
        public LoaiSach LoaiSach { get; set; }
        [MaxLength(50)]
        public string TacGia { get; set; }
        [MaxLength(50)]
        public string MaNXB { get; set; }
        [ForeignKey("MaNXB")]
        public NhaXuatBan NhaXuatBan { get; set; }
        public int GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int SoTrang { get; set; }
        public string images { get; set; }
        public DateTime NamXuatBan { get; set; }
        public string NoiDung { get; set; }
    }
}