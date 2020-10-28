using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _28_10.Models
{
    [Table("LoaiSachs")]
    public class LoaiSach
    {
        [Key]
        [Required,MaxLength(50)]
        public string Maloaisach { get; set; }
        public ICollection<Sach> Sachs { get; set; }
        [Required, MaxLength(50)]
        public string Tenloaisach { get; set; }
    }
}