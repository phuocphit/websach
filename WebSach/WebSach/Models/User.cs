using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSach.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [MaxLength(50)]
        public string Email { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [MaxLength(50)]
        public string RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }
    }
}