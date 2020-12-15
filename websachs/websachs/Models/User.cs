using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace websachs.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [MaxLength(50)]
        public string UserName { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [NotMapped]
        [Required, MaxLength(50)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("PassWord")]
        public string ConfirmPassWord { get; set; }
        public string RoleName { get; set; }

    }
}