﻿namespace Vidly.Models
{
    public class Customer
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public MembershipType? MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
