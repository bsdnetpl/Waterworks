using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waterworks.DTO;
using Waterworks.Service;

namespace Waterworks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinnessClientController : ControllerBase
    {
        private readonly IBussinesClientService _bussinesClientService;
        public BusinnessClientController(IBussinesClientService bussinesClientService)
        {
            _bussinesClientService = bussinesClientService;
        }
        [HttpGet("GetBiusinesClient")]
        public ActionResult<BusinessClient> GetBiusinesClient(Guid IdBiusinesClient)
        {
           return  _bussinesClientService.GetBiusinesClient(IdBiusinesClient);
        }
        [HttpPost("AddBiusinesClient")]
        public ActionResult<bool> AddBiusinesClient(BusinessClientDTO businessClientDTO)
        {
           return  _bussinesClientService.AddBiusinesClient(businessClientDTO);
        }
        [HttpPut("EditBiusinesClient")]
        public ActionResult<BusinessClient> EditBiusinesClient(Guid IdBiusinesClient, BusinessClientDTO businessClientDTO)
        {
           return _bussinesClientService.EditBiusinesClient(IdBiusinesClient, businessClientDTO);
        }
    }
}
