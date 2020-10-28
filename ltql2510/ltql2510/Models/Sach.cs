using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ltql2510.Models
{
    public class Sach
    {
        [Key]
        public int Masach { get; set; }
        public string Tensach { get; set; }
        public string Ngayxuatban { get; set; }
        public string Giasach { get; set; }
        public string Matacgia { get; set; }
        public int Maloaisach { get; set; }
        [ForeignKey("Maloaisach")]
        public LoaiSach LoaiSach { get; set; }
    }
}