using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel : FormViewModel<Customer>
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateOnly? Birthdate { get; set; }

        [Display(Name = "Subscribe to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        [Display(Name = "Select Membership Type")]
        public byte MembershipTypeId { get; set; }

        public IEnumerable<MembershipType>? MembershipTypes { get; set; }

        public CustomerFormViewModel() : base()
        {
        }

        public CustomerFormViewModel(string action, Customer customer, IEnumerable<MembershipType> membershipTypes)
            : base(action, customer)
        {
            MembershipTypes = membershipTypes;
        }
    }
}
