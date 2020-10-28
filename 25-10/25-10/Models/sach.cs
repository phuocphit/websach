using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _25_10.Models
{
    public class sach
    {
        [Key]
        public int Masach { get; set; }
        public string Tensach { get; set; }
        public string Ngayxuatban { get; set; }
        public string Giasach { get; set; }
        public string Matacgia { get; set; }
        public int Maloaisach { get; set; }
        [ForeignKey("Maloaisach")]
        public sach sach { get; set; }
    }
}