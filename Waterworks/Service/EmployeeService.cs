using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Waterworks.DB;
using Waterworks.DTO;

namespace Waterworks.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly ConnectMssql _connectMssql;
        private readonly IPasswordHasher<Employee> _passwordHasher;
        private readonly IValidator<Employee> _validator;

        public EmployeeService(IMapper mapper, ConnectMssql connectMssql, IPasswordHasher<Employee> passwordHasher, IValidator<Employee> validator)
        {
            _mapper = mapper;
            _connectMssql = connectMssql;
            _passwordHasher = passwordHasher;
            _validator = validator;
        }
        public bool AddEmployeer(Employee employee)
        {
            var result = _mapper.Map<Employee>(employee);
            result.id = Guid.NewGuid();
            result.CreatedDate = DateTime.Now;
            result.Password = _passwordHasher.HashPassword(result, employee.Password);
            _connectMssql.employees.Add(result);
            _connectMssql.SaveChanges();
            return true;
        }

        public Employee EditEmployee(Employee employee)
        {
            var result = _connectMssql.employees.Find(employee.id);
            if (result is null)
            {

            }
            result.PhoneNumber = employee.PhoneNumber;
            result.Email = employee.Email;
            result.PhoneNumber = employee.PhoneNumber;
            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Password = _passwordHasher.HashPassword(result, employee.Password);
            _connectMssql.SaveChanges();
            return result;
        }
        public Employee GetEmployee(Guid guidCustomer)
        {
            return _connectMssql.employees.Find(guidCustomer);
        }

    }
}
