using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository;

public interface IContactRepository
{
    void CreateContact(CreateContactDto contactDto);
    Task<List<ResultContactDto>> GetAllContactsAsync();
    Task<GetByIDContactDto> GetContactByID(int id);
    Task<List<ResultLastContactsDto>> GetLastContacts();
    void UpdateContact(UpdateContactDto contactDto);
    void DeleteContact(int id);
}
