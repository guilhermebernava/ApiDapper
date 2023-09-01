using Services.Dtos;

namespace Services.Services;

public interface IPersonUpdateServices
{
    Task<bool> ExecuteAsync(PersonDto dto);
}
