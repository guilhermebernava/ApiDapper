using Domain.Entities;
using Repositories;

namespace Services.Services;

public class PersonGetByIdServices : IPersonGetByIdServices
{
    private readonly IPersonRepository _personRepository;

    public PersonGetByIdServices(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> ExecuteAsync(Guid id)
    {
        return await _personRepository.GetByIdAsync(id);
    }
}
