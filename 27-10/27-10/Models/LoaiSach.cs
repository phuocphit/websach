using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _27_10.Models
{
    [Table("LoaiSachs")]
    public class LoaiSach
    {
        [Key]
        public string Maloaisach { get; set; }
        public ICollection<Sach> Sachs { get; set; }
        public string Tenloaisach { get; set; }
    }
}