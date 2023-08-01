using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waterworks.DTO;
using Waterworks.Service;

namespace Waterworks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablePaymentController : ControllerBase
    {
        private readonly ITablePaymentServices _TablePaymentServices;

        public TablePaymentController(ITablePaymentServices TablePaymentServices)
        {
            _TablePaymentServices = TablePaymentServices;
        }

        [HttpPost("AddPayment")]
        public ActionResult<bool> AddPayment(TablePayment tablePayment)
        {
           return  _TablePaymentServices.AddPayment(tablePayment);
        }

        [HttpDelete("DeletePayment")]
        public ActionResult<bool> DeletePayment(Guid tablePayment)
        {
            return _TablePaymentServices.DeletePayment(tablePayment);
        }
    }
}
