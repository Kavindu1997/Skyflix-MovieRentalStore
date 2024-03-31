using System.ComponentModel.DataAnnotations;

namespace SkyFlix.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        // [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto? MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}