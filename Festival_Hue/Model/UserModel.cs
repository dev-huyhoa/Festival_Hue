using Festival_Hue.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festival_Hue.Models
{
    [Table("User")]

    public class UserModel
    {
        [Key]
        public Guid IdUser { get; set; }
        [Display(Name = "Họ và Tên"), Required]
        [StringLength(30)]
        public string NameUser { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime UserBirthday { get; set; }
        [Display(Name = "Email"), Required]
        [StringLength(30)]
        public string EmailUser { get; set; }
        [Display(Name = "Password"), Required]
        [StringLength(50)]
        public string PasswordUser { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(30)]
        public string Address { get; set; }
        [Display(Name = "Điện thoại")]
        [StringLength(15)]
        public string Phone { get; set; }
        public bool IsDelete { get; set; }

        [ForeignKey("RoleModel")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public RoleModel Role { get; set; }
    }
}
