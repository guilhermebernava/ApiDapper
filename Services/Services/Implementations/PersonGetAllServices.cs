using Domain.Entities;
using Repositories;

namespace Services.Services;

public class PersonGetAllServices : IPersonGetAllServices
{
    private readonly IPersonRepository _personRepository;

    public PersonGetAllServices(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<List<Person>> ExecuteAsync()
    {
        return await _personRepository.GetAllAsync();
    }
}
