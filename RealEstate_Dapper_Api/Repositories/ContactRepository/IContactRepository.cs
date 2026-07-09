using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository;

public interface IContactRepository
{
    Task CreateContact(CreateContactDto contactDto);
    Task<List<ResultContactDto>> GetAllContacts();
    Task<GetByIDContactDto> GetContactByID(int id);
    Task<List<ResultLastContactsDto>> GetLastContacts();
    Task UpdateContact(UpdateContactDto contactDto);
    Task DeleteContact(int id);
}
