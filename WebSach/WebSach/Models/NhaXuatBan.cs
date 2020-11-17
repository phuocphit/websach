using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSach.Models
{
    [Table("NhaXuatBans")]
    public class NhaXuatBan
    {
        [Key]
        [MaxLength(50)]
        public string MaNXB { get; set; }
        public ICollection<Sach> Sachs { get; set; }
        [MaxLength(50)]
        public string TenNXB { get; set; }
    }
}