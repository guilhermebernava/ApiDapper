using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services;

public static class ServicesInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonCreateServices, PersonCreateServices>();
        services.AddScoped<IPersonUpdateServices, PersonUpdateServices>();
        services.AddScoped<IPersonDeleteServices, PersonDeleteServices>();
        services.AddScoped<IPersonGetAllServices, PersonGetAllServices>();
        services.AddScoped<IPersonGetByIdServices, PersonGetByIdServices>();
    }
}
