using Repositories;

namespace Services.Services;

public class PersonDeleteServices : IPersonDeleteServices
{
    private readonly IPersonRepository _personRepository;

    public PersonDeleteServices(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id)
    {
        return await _personRepository.DeleteAsync(id);
    }
}
