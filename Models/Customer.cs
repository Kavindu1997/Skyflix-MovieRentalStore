using System.ComponentModel.DataAnnotations;

namespace SkyFlix.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [StringLength(255)]
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType? MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

    }
}