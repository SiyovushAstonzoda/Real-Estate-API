using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactsController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto contactDto)
    {
        await _contactRepository.CreateContact(contactDto);
        return Ok("New Contact has been created");
    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        var values = await _contactRepository.GetAllContacts();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ContactById(int id)
    {
        var value = await _contactRepository.GetContactByID(id);
        return Ok(value);
    }

    [HttpGet("GetLastContacts")]
    public async Task<IActionResult> GetLastContacts()
    {
        var values = await _contactRepository.GetLastContacts();
        return Ok(values);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactDto contactDto)
    {
        await _contactRepository.UpdateContact(contactDto);
        return Ok("Contact has been updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        await _contactRepository.DeleteContact(id);
        return Ok("Contact with Id = " + id + " has been deleted");
    }
}
