using Waterworks.DTO;

namespace Waterworks.Service
{
    public interface ITablePaymentServices
    {
        bool AddPayment(TablePayment tablePayment);
        bool DeletePayment(Guid IdPyment);
    }
}