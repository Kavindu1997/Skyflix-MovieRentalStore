using SkyFlix.Models;

namespace SkyFlix.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType>? MembershipTypes { get; set; }
        public Customer? Customer { get; set; }
    }


}