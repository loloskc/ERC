using System;
using System.Collections.Generic;

#nullable disable

namespace ERC
{
    public partial class ElectricityBill
    {
        public int Id { get; set; }
        public int QuantityHuman { get; set; }
        public double? Hvc { get; set; }
        public double? Gvc { get; set; }
        public double? GvcE { get; set; }
        public double? Ii { get; set; }
        public double? IiNight { get; set; }
    }
}
