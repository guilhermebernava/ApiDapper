using Services.Dtos;

namespace Services.Services;

public interface IPersonCreateServices
{
    Task<bool> ExecuteAsync(PersonDto dto);
}
