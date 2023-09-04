using Domain.Entities;
using Repositories;
using Services.CacheServices;

namespace Services.Services;

public class PersonGetByIdServices : IPersonGetByIdServices
{
    private readonly IPersonRepository _personRepository;
    private readonly ICache _cache;

    public PersonGetByIdServices(IPersonRepository personRepository, ICache cache)
    {
        _personRepository = personRepository;
        _cache = cache;
    }

    public async Task<Person> ExecuteAsync(Guid id)
    {
        var existent = _cache.GetOrCreate<Person>(id.ToString());

        if (existent == null)
        {
            var product = await _personRepository.GetByIdAsync(id);
            _cache.GetOrCreate(id.ToString(), product);
            return product;
        }
        return existent;
    }
}
