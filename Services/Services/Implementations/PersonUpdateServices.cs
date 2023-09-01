using AutoMapper;
using Domain.Entities;
using Repositories;
using Services.Dtos;

namespace Services.Services;

public class PersonUpdateServices : IPersonUpdateServices
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonUpdateServices(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<bool> ExecuteAsync(PersonDto dto)
    {
        if(dto.Id == null) return false;    
        var person = _mapper.Map<Person>(dto);
        return await _personRepository.UpdateAsync(person);
    }
}
