using Festival_Hue.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festival_Hue.Model
{
    [Table("Role")]
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        [Display(Name = "Tên chức vụ"), Required]
        [StringLength(30)]
        public string RoleName { get; set; }
        public ICollection<UserModel> User { get; set; }

    }
}
