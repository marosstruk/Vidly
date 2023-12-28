using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public string? Action { get; set; }

        public int Id { get; set; }

        public string? Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateOnly? Birthdate { get; set; }

        [Display(Name = "Subscribe to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Select Membership Type")]
        public byte MembershipTypeId { get; set; }

        public IEnumerable<MembershipType>? MembershipTypes { get; set; }
    }
}
