using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Waterworks.DB;
using Waterworks.DTO;

namespace Waterworks.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IMapper _mapper;
        private readonly ConnectMssql _connectMssql;
        private readonly IPasswordHasher<Customer> _passwordHasher;
        public CustomerService(IMapper mapper, ConnectMssql connectMssql, IPasswordHasher<Customer> passwordHasher)
        {
            _mapper = mapper;
            _connectMssql = connectMssql;
            _passwordHasher = passwordHasher;
        }
        public bool AddCustomer(CustomerDTO customer)
        {
            var result = _mapper.Map<Customer>(customer);
            result.Id = Guid.NewGuid();
            result.CreatedDate = DateTime.Now;
            result.Password = _passwordHasher.HashPassword(result, customer.Password);
            _connectMssql.customers.Add(result);
            _connectMssql.SaveChanges();
            return true;
        }


    }
}
