using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festival_Hue.Model
{
    [Table("Ticket")]
    public class TicketModel
    {
        [Key]
        public int IdTicket { get; set; }
        [Display(Name = "Tên vé"), Required]
        [StringLength(30)]
        public string NameTicket { get; set; }
        public float PriceTicket { get; set; }
        [Display(Name = "Số Vé")]
        [StringLength(10)]
        public string TicketNo { get; set; }
        [Display(Name = "Trạng thái"), Required]
        public int Status { get; set; }
        [Display(Name = "Mã Voucher"), Required]
        [StringLength(10)]
        public string VoucherCode { get; set; }

        public int VoucherValue { get; set; }
        public float FinalPrice { get; set; }
        public DateTime DatePurchase { get; set; }
        [ForeignKey("EventModel")]
        public int EventId { get; set; }
        public EventModel Event { get; set; }
        public ICollection<CustomerModel> Customer { get; set; }
        public bool IsDelete { get; set; } 
    }
}
