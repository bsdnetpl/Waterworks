using Waterworks.DTO;

namespace Waterworks.Service
{
    public interface ICustomerService 
    {
        bool AddCustomer(CustomerDTO customer);
    }
}
