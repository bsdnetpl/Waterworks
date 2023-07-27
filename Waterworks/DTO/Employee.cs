using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Waterworks.DTO
{
    public class Employee
    {
        public Guid id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password{ get; set; }
        public string Role { get; set; }
    }

    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(customer => customer.Email).NotNull().WithMessage("Email cannot be empty");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Wrong email address");
            RuleFor(customer => customer.PhoneNumber).NotNull().WithMessage("Phone Number cannot be empty");
            RuleFor(customer => customer.Password).Length(8, 25).WithMessage("The password must contain a minimum of 8 characters and a maximum of 25 characters");

        }
    }
}
