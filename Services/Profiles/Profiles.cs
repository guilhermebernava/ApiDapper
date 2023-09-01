using AutoMapper;
using Domain.Entities;
using Services.Dtos;

namespace Services.Profiles;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<PersonDto, Person>();
        CreateMap<Person, PersonDto>();
    }
}
