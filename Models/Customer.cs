using System.ComponentModel.DataAnnotations;

namespace SkyFlix.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType? MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}