using Waterworks.DTO;

namespace Waterworks.Service
{
    public interface ICustomersPaymentService
    {
        bool AddPayment(CustomersPaymentDTO customersPaymentDTO, Guid idUser);
        bool EditPayment(CustomersPaymentDTO customersPaymentDTO, Guid idPayment, Guid IdEployee);
    }
}