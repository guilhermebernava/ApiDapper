using Domain.Entities;
using Repositories;
using Services.CacheServices;

namespace Services.Services;

public class PersonGetAllServices : IPersonGetAllServices
{
    private readonly IPersonRepository _personRepository;
    private readonly ICache _cache;

    public PersonGetAllServices(IPersonRepository personRepository, ICache cache)
    {
        _personRepository = personRepository;
        _cache = cache;
    }

    public async Task<List<Person>> ExecuteAsync()
    {
        var existents = _cache.GetOrCreate<List<Person>>("products");

        if(existents == null)
        {
            var products = await _personRepository.GetAllAsync();
            _cache.GetOrCreate("products", products);
            return products;
        }
        return existents;
    }
}
