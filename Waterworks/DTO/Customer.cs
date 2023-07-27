using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Waterworks.DTO
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
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
        public string PhoneNumber { get; set; } = string.Empty;
        public string CounterNymber { get; set; }
        public bool BlockClient { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Email).NotNull().WithMessage("Email cannot be empty");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Wrong email address");
            RuleFor(customer => customer.PhoneNumber).NotNull().WithMessage(".Phone Number cannot be empty");
            RuleFor(customer => customer.Password).Length(8,25).WithMessage("The password must contain a minimum of 8 characters and a maximum of 25 characters");

        }
    }
}
