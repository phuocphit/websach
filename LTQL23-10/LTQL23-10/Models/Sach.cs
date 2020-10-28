using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL23_10.Models
{
    
    public class Sach
    {
        [Key]
        public int Masach { get; set; }
        public string Tensach { get; set; }
        public string Ngayxuatban { get; set; }
        public string Giasach { get; set; }
        public string Matacgia { get; set; }
        public ICollection<Loaisach> Loaisaches { get; set; }
    }
}