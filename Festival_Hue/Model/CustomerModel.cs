using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festival_Hue.Model
{
    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        public Guid IdCustomer { get; set; }
        [Display(Name = "Tên khách hàng"), Required]
        [StringLength(30)]
        public string NameCustomer { get; set; }
        [Display(Name = "Điện thoại")]
        [StringLength(15)]
        public string PhoneCustomer { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(55)]
        public string Address { get; set; }
        [Display(Name = "Địa chỉ"), Required]
        [StringLength(55)]
        public string Email { get; set; }
        [Display(Name = "Password"), Required]
        [StringLength(30)]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsDelete { get; set; }
        [ForeignKey("TicketModel")]
        
        public TicketModel Ticket { get; set; }
        public int TicketId { get; set; }
    }
}
