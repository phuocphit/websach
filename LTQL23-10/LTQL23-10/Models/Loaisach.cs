using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL23_10.Models
{
    
    public class Loaisach
    {
        [Key]
        public int Maloaisach { get; set; }
        public int Maloaisach_id { get; set; }
        [ForeignKey("Maloaisach_id")]
        public Sach Sach { get; set; }
        public string Tenloaisach { get; set; }
        
    }
}