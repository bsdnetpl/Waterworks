using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Waterworks.DB;
using Waterworks.DTO;

namespace Waterworks.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IMapper _mapper;
        private readonly ConnectMssql _connectMssql;
        private readonly IPasswordHasher<Customer> _passwordHasher;
        private readonly IValidator<CustomerDTO> _validator;
        public CustomerService(IMapper mapper, ConnectMssql connectMssql, IPasswordHasher<Customer> passwordHasher, IValidator<CustomerDTO> validatores)
        {
            _mapper = mapper;
            _connectMssql = connectMssql;
            _passwordHasher = passwordHasher;
            _validator = validatores;
        }
        public bool AddCustomer(CustomerDTO customer)
        {

            ValidationResult resultVal = _validator.Validate(customer);
            var result = _mapper.Map<Customer>(customer);
            result.Id = Guid.NewGuid();
            result.CreatedDate = DateTime.Now;
            result.Password = _passwordHasher.HashPassword(result, customer.Password);
           
            _connectMssql.customers.Add(result);
            _connectMssql.SaveChanges();
            return true;
        }

        public Customer? GetCustomers(Guid guidCustomer)
        {
            return _connectMssql.customers.Find(guidCustomer);
        }
    }
}
