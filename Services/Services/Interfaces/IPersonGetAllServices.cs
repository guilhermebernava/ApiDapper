using Domain.Entities;

namespace Services.Services;

public interface IPersonGetAllServices
{
    Task<List<Person>> ExecuteAsync();
}
