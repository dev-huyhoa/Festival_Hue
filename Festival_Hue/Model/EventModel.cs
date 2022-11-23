using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festival_Hue.Model
{
    [Table("Event")]
    public class EventModel
    {
        [Key]
        public int IdEvent { get; set; }
        [Display(Name = "Tên sự kiện"), Required]
        [StringLength(30)]
        public string NameEvent { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(255)]
        public string Address { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Display(Name = "Mô tả")]
        [StringLength(30)]
        public string Description { get; set; }
        public float PriceEvent { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<TicketModel> Ticket { get; set; }
    }
}
