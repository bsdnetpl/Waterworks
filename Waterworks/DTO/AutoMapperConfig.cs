using AutoMapper;

namespace Waterworks.DTO
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<BusinessClient, BusinessClientDTO>().ReverseMap();
            CreateMap<CustomersPayment, CustomersPaymentDTO>().ReverseMap();
        }
    }
}
