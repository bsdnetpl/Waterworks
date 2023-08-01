using Waterworks.DTO;

namespace Waterworks.Service
{
    public interface ICustomerService 
    {
        bool AddCustomer(CustomerDTO customer);
        Customer? GetCustomers(Guid guidCustomer);
        Customer EditCustomer(Guid customerId, CustomerDTO customerDTO);
        bool DeleteCustomers(Guid UserUId, Guid EmployeeId);
    }
}
