using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository;

public class ContactRepository : IContactRepository
{
    private readonly Context _context;

    public ContactRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateContact(CreateContactDto contactDto)
    {
        string query = @"Insert Into Contact (Name, Subject, Email, Message, SendDate)
                        Values (@name, @subject, @email, @message, @sendDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@name", contactDto.Name);
        parameters.Add("@subject", contactDto.Subject);
        parameters.Add("@email", contactDto.Email);
        parameters.Add("@message", contactDto.Message);
        parameters.Add("@sendDate", contactDto.SendDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultContactDto>> GetAllContacts()
    {
        string query = @"Select *
                        From Contact";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultContactDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIDContactDto> GetContactByID(int id)
    {
        string query = @"Select * 
                        From Contact
                        Where ContactID=@contactID";
        var parameters = new DynamicParameters();
        parameters.Add("@contactID", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIDContactDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<ResultLastContactsDto>> GetLastContacts()
    {
        string query = @"Select Top(4) *
                        From Contact
                        Order By ContactID Desc";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastContactsDto>(query);
            return values.ToList();
        }
    }

    public async Task UpdateContact(UpdateContactDto contactDto)
    {
        string query = @"Update Contact 
                        Set Name=@name,Subject=@subject,Email=@email,Message=@message,SendDate=@sendDate
                        Where ContactID=@contactID";
        var parameters = new DynamicParameters();
        parameters.Add("@name", contactDto.Name);
        parameters.Add("@subject", contactDto.Subject);
        parameters.Add("@email", contactDto.Email);
        parameters.Add("@message", contactDto.Message);
        parameters.Add("@sendDate", contactDto.SendDate);
        parameters.Add("@contactID", contactDto.ContactID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteContact(int id)
    {
        string query = @"Delete From Contact
                        Where ContactID = @contactID";
        var parameters = new DynamicParameters();
        parameters.Add("@contactID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
