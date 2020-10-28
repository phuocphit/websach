using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _25_10.Models
{
    public class loaisach
    {
        [Key]
        public int Maloaisach { get; set; }
        public ICollection<loaisach> loaisachs { get; set; }
        public string Tenloaisach { get; set; }
    }
}