using Waterworks.DB;
using Waterworks.DTO;

namespace Waterworks.Service
{
    public class TablePaymentServices
    {
        private readonly ConnectMssql _connectMssql;

        public TablePaymentServices(ConnectMssql connectMssql)
        {
            _connectMssql = connectMssql;
        }

        public bool AddPayment(TablePayment tablePayment)
        {
            _connectMssql.tablePayments.Add(tablePayment);
            return true;
        }
        public bool DeletePayment(Guid IdPyment)
        {
            var result = _connectMssql.tablePayments.Find(IdPyment);
            _connectMssql.tablePayments.Remove(result);
            _connectMssql.SaveChanges();
            return true;
        }
    }
}
