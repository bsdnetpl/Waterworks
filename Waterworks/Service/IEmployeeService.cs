using Waterworks.DTO;

namespace Waterworks.Service
{
    public interface IEmployeeService
    {
        bool AddEmployeer(Employee employee);
        Employee EditEmployee(Employee employee);
        Employee GetEmployee(Guid guidCustomer);
    }
}