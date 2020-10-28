using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _27_10.Models
{
    [Table("Sachs")]
    public class Sach
    {
        [Key]
        public string Masach { get; set; }
        public string Tensach { get; set; }
        public DateTime Ngayxuatban { get; set; }
        public int Giasach { get; set; }
        public string Matacgia { get; set; }
        public string Maloaisach { get; set; }
        [ForeignKey("Maloaisach")]
        public LoaiSach LoaiSach { get; set; }
    }
}