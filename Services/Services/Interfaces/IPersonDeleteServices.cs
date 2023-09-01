namespace Services.Services;

public interface IPersonDeleteServices
{
    Task<bool> ExecuteAsync(Guid id);
}
