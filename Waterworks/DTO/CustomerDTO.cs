﻿using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Waterworks.DB;
using Waterworks.DTO;

namespace Waterworks.DTO
{
    public class CustomerDTO
    {
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
        public string CounterNymber { get; set; }
        public Guid IdOffer { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

public class CustomerDTOValidator : AbstractValidator<CustomerDTO>
{
    public CustomerDTOValidator(ConnectMssql connectMssql)
    {
        RuleFor(customer => customer.Email).NotNull().NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(customer => customer.Email).EmailAddress().WithMessage("Wrong email address");
        RuleFor(customer => customer.PhoneNumber).NotNull().NotEmpty().WithMessage(".Phone Number cannot be empty");
        RuleFor(customer => customer.Password).Length(8, 25).NotNull().NotEmpty().WithMessage("The password must contain a minimum of 8 characters and a maximum of 25 characters");
        RuleFor(x => x.Email)
            .Custom((value, context) =>
            {
                var emailIsInUse = connectMssql.customers.Any(u => u.Email == value);
                if (emailIsInUse)
                {
                    context.AddFailure("This email is already taken");
                }
            });

    }
}
