using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Waterworks.DB;
using Waterworks.DTO;

namespace Waterworks.Service
{
    public class BussinesClientService : IBussinesClientService
    {
        private readonly ConnectMssql _connectMssql;
        private readonly IPasswordHasher<BusinessClient> _passwordHasher;
        private readonly IMapper _mapper;

        public BussinesClientService(ConnectMssql connectMssql, IPasswordHasher<BusinessClient> passwordHasher, IMapper mapper = null)
        {
            _connectMssql = connectMssql;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }


        public BusinessClient GetBiusinesClient(Guid IdBiusinesClient)
        {
            return _connectMssql.businessClients.Find(IdBiusinesClient);
        }

        public bool AddBiusinesClient(BusinessClientDTO businessClientDTO)
        {
            var result = _mapper.Map<BusinessClient>(businessClientDTO);
            result.Id = Guid.NewGuid();
            result.CreatedDate = DateTime.Now;
            result.Password = _passwordHasher.HashPassword(result, businessClientDTO.Password);
            _connectMssql.businessClients.Add(result);
            _connectMssql.SaveChanges();
            return true;
        }

        public BusinessClient EditBiusinesClient(Guid IdBiusinesClient, BusinessClientDTO businessClientDTO)
        {
            var result = _connectMssql.businessClients.Find(IdBiusinesClient);
            if (result is null)
            {

            }
            result.PhoneNumber = businessClientDTO.PhoneNumber;
            result.Email = businessClientDTO.Email;
            result.City = businessClientDTO.City;
            result.Country = businessClientDTO.Country;
            result.Address = businessClientDTO.Address;
            result.CounterNymber = businessClientDTO.CounterNymber;
            result.IdOffer = businessClientDTO.IdOffer;
            result.Name = businessClientDTO.Name;
            result.LastName = businessClientDTO.LastName;
            result.PostalCode = businessClientDTO.PostalCode;
            result.Country = businessClientDTO.Country;
            result.Password = businessClientDTO.Password;
            _connectMssql.SaveChanges();
            return result;
        }
    }
}
