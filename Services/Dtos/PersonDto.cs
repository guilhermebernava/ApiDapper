namespace Services.Dtos;

public record PersonDto(string Name,string Surname, int Age, DateTime Birthday, string Gender, Guid? Id);

