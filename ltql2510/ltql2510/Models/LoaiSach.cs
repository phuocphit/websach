using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ltql2510.Models
{
    public class LoaiSach
    {
        [Key]
        public int Maloaisach { get; set; }
        public ICollection<Sach> Sachs { get; set; }
        public string Tenloaisach { get; set; }
    }
}