namespace Vidly.Models
{
    public class Customer
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly? Birthdate { get; set; }
        public required bool IsSubscribedToNewsletter { get; set; }
        public MembershipType? MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
