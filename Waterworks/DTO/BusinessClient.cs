using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Waterworks.DTO
{
    public class BusinessClient
    {
        public Guid Id { get; set; }
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
        public string PhoneNumber { get; set; } = string.Empty;
        public string CounterNymber { get; set; }
        public bool BlockClient { get; set; } = false;
        public DateTime CreatedDate { get; set; }
    }

    public class BusinessClientValidator : AbstractValidator<BusinessClient>
    {
        public BusinessClientValidator()
        {
            RuleFor(customer => customer.Email).NotNull().NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Wrong email address");
            RuleFor(customer => customer.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone Number cannot be empty");
            RuleFor(customer => customer.Password).Length(8, 25).NotNull().NotEmpty().WithMessage("The password must contain a minimum of 8 characters and a maximum of 25 characters");

        }
    }
}
