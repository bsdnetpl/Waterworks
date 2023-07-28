using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Waterworks.DB;

namespace Waterworks.DTO
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
        public Guid IdOffer { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string CounterNymber { get; set; }
        public bool BlockClient { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        
    }


}
