using Repositories;
using Infra.Repositories;
using Services.Profiles;
using Services;
using Services.Services;
using Services.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(Profiles));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/Person/GetAll", async (IPersonGetAllServices service)  =>  
{
    return Results.Ok(await service.ExecuteAsync());
});

app.MapGet("/Person/GetById", async (Guid id, IPersonGetByIdServices service) =>
{
    return Results.Ok(await service.ExecuteAsync(id));
});

app.MapPost("/Person/", async (PersonDto dto, IPersonCreateServices service) =>
{
    var created = await service.ExecuteAsync(dto);
    if (created) return Results.Created("/Person/GetAll", null);
    return Results.BadRequest();
});

app.MapPut("/Person/", async (PersonDto dto, IPersonUpdateServices service) =>
{
    var updated = await service.ExecuteAsync(dto);
    if (updated) return Results.Ok();
    return Results.BadRequest();
});

app.MapDelete("/Person/", async (Guid id, IPersonDeleteServices service) =>
{
    var deleted = await service.ExecuteAsync(id);
    if (deleted) return  Results.Ok();
    return Results.BadRequest();
});

app.UseHttpsRedirection();
app.Run();
