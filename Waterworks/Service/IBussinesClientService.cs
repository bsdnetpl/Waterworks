using Waterworks.DTO;

namespace Waterworks.Service
{
    public interface IBussinesClientService
    {
        bool AddBiusinesClient(BusinessClientDTO businessClientDTO);
        BusinessClient EditBiusinesClient(Guid IdBiusinesClient, BusinessClientDTO businessClientDTO);
        BusinessClient GetBiusinesClient(Guid IdBiusinesClient);
        bool DeleteBiusinesClient(Guid UserUId, Guid EmployeeId);
    }
}