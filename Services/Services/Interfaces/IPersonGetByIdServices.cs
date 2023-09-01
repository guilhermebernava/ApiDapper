using Domain.Entities;

namespace Services.Services;

public interface IPersonGetByIdServices
{
    Task<Person> ExecuteAsync(Guid id);
}
