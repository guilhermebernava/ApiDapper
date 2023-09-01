using AutoMapper;
using Domain.Entities;
using Repositories;
using Services.Dtos;

namespace Services.Services;

public class PersonCreateServices : IPersonCreateServices
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonCreateServices(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<bool> ExecuteAsync(PersonDto dto)
    {
        var person = _mapper.Map<Person>(dto);
        return await _personRepository.AddAsync(person);
    }
}
