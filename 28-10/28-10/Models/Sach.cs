using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _28_10.Models
{
    [Table("Sachs")]
    public class Sach
    {
        [Key]
        [Required, MaxLength(50)]
        public string Masach { get; set; }
        [Required, MaxLength(50)]
        public string Tensach { get; set; }
        public DateTime Ngayxuatban { get; set; }
        public int Giasach { get; set; }
        [Required, MaxLength(50)]
        public string Matacgia { get; set; }
        [Required, MaxLength(50)]
        public string Maloaisach { get; set; }
        [ForeignKey("Maloaisach")]
        public LoaiSach LoaiSach { get; set; }
    }
}