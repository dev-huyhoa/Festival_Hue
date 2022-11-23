using System;

namespace Festival_Hue.Model
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Value { get; set; }
        public string IsDelete { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
