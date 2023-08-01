using AutoMapper;
using Waterworks.DB;
using Waterworks.DTO;

namespace Waterworks.Service
{
    public class CustomersPaymentService : ICustomersPaymentService
    {
        private readonly ConnectMssql _connectMssql;
        private readonly IMapper _mapper;

        public CustomersPaymentService(ConnectMssql connectMssql, IMapper mapper = null)
        {
            _connectMssql = connectMssql;
            _mapper = mapper;
        }

        public bool AddPayment(CustomersPaymentDTO customersPaymentDTO, Guid idUser)
        {
            var result = _mapper.Map<CustomersPayment>(customersPaymentDTO);
            result.Id = Guid.NewGuid();
            result.DateCheck = DateTime.Now;
            result.isPayed = false;
            result.UserId = idUser;
            _connectMssql.customersPayments.Add(result);
            _connectMssql.SaveChanges();
            return true;
        }
        public bool EditPayment(CustomersPaymentDTO customersPaymentDTO, Guid idPayment, Guid IdEployee)
        {
            var resultCheck = _connectMssql.employees.Find(IdEployee);
            if (resultCheck == null)
            {
                return false;
            }
            var resultSeek = _connectMssql.customersPayments.Find(idPayment);
            resultSeek.brutto = customersPaymentDTO.brutto;
            resultSeek.netto = customersPaymentDTO.netto;
            resultSeek.Vat = customersPaymentDTO.Vat;
            resultSeek.DateCheck = DateTime.Now;
            resultSeek.isPayed = false;
            resultSeek.CounterCheckValue = customersPaymentDTO.CounterCheckValue;
            _connectMssql.SaveChanges();
            return true;
        }
    }
}
