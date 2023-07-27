using System.ComponentModel.DataAnnotations;

namespace Waterworks.DTO
{
    public class BusinessClientDTO
    {
        public string NameBiussines { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string NIP { get; set; }
        public string Regon { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
        public Guid IdOffer { get; set; }
        public string CounterNymber { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
