using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSach.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [MaxLength(50)]
        public string RoleID { get; set; }
        public ICollection<User> Users { get; set; }
        [MaxLength(50)]
        public string RoleName { get; set; }
    }
}