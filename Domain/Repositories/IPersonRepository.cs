using Domain.Entities;

namespace Repositories;

public interface IPersonRepository
{
    Task<bool> AddAsync(Person person);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateAsync(Person person);
    Task<Person> GetByIdAsync(Guid id);
    Task<List<Person>> GetAllAsync();
}
