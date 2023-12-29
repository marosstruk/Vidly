using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public required int Id { get; set; }

        [StringLength(255)]
        public required string Name { get; set; }

        [Min18YearsIfAMember]
        public DateOnly? Birthdate { get; set; }

        public required bool IsSubscribedToNewsletter { get; set; }

        public MembershipType? MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}
