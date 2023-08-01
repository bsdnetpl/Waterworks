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

            //ValidationResult resultVal = _validator.Validate(customer);
            var result = _mapper.Map<Customer>(customer);
            result.Id = Guid.NewGuid();
            result.CreatedDate = DateTime.Now;
            result.Password = _passwordHasher.HashPassword(result, customer.Password);
            _connectMssql.customers.Add(result);
            _connectMssql.SaveChanges();
            return true;
        }

        public Customer EditCustomer(Guid customerId, CustomerDTO customerDTO)
        {
            var result = _connectMssql.customers .Find(customerId);
          if(result is null)
            {
                
            }
            result.PhoneNumber = customerDTO.PhoneNumber;
            result.Email = customerDTO.Email;
            result.City = customerDTO.City;
            result.Country = customerDTO.Country;
            result.Address = customerDTO.Address;
            result.CounterNymber = customerDTO.CounterNymber;
            result.IdOffer = customerDTO.IdOffer;
            result.Name = customerDTO.Name;
            result.LastName = customerDTO.LastName;
            result.PostalCode = customerDTO.PostalCode;
            result.Country = customerDTO.Country;
            result.Password = customerDTO.Password;
            _connectMssql.SaveChanges();
            return result;
        }
        public Customer? GetCustomers(Guid guidCustomer)
        {
            return _connectMssql.customers.Find(guidCustomer);
        }
        public bool DeleteCustomers(Guid UserUId, Guid EmployeeId)
        {
            var resultCheck = _connectMssql.employees.Find(EmployeeId);
            if (resultCheck == null)
            {
                return false;
            }
            var delProd = _connectMssql.customers.Find(UserUId);
            _connectMssql.customers.Remove(delProd);
            _connectMssql.SaveChanges();
            return true;
        }
    }
}
