﻿namespace Vidly.Models
{
    public class MembershipType
    {
        public required byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
