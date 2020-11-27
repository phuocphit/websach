using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace websachs.Models
{
    [Table("LoaiSachs")]
    public class LoaiSach
    {
        [Key]
        [MaxLength(50)]
        public string MaLoaiSach { get; set; }
        public ICollection<Sach> Sachs { get; set; }
        [MaxLength(50)]
        public string TenLoaiSach { get; set; }
    }
}