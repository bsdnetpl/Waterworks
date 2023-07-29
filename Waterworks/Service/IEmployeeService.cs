using Waterworks.DTO;

namespace Waterworks.Service
{
    public interface IEmployeeService
    {
        bool AddCustomer(Employee employee);
        Employee EditCustomer(Employee employee);
        Employee GetCustomer(Guid guidCustomer);
    }
}