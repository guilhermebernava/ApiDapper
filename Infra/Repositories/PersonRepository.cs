using Dapper;
using Domain.Entities;
using Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infra.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly string _connectionString;


    public PersonRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Not found any STRING TO CONNECT");
    }


    public async Task<bool> AddAsync(Person person)
    {
        using var db = new SqlConnection(_connectionString);
        var result = await db.ExecuteAsync(@"INSERT INTO Persons (Id, Name, Surname, Age, Gender, Birthday) VALUES (@Id, @Name, @Surname, @Age, @Gender, @Birthday)",
            new
            {
                Id = Guid.NewGuid(),
                person.Name,
                person.Surname,
                person.Age,
                person.Gender,
                person.Birthday
            });
        return result == 1;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var db = new SqlConnection(_connectionString);
        var result = await db.ExecuteAsync("DELETE FROM [dbo].[Persons] Where [Id] = @Id", new { Id = id });
        return result == 1;
    }
    public async Task<List<Person>> GetAllAsync()
    {
        using var db = new SqlConnection(_connectionString);
        var persons = await db.QueryAsync<Person>("SELECT * FROM [dbo].[Persons] Order By [Name]");
        return persons.ToList();
    }

    public async Task<Person> GetByIdAsync(Guid id)
    {
        using var db = new SqlConnection(_connectionString);
        var person = await db.QueryFirstOrDefaultAsync<Person>("person_get_by_id", new { Id = id }, commandType: CommandType.StoredProcedure) ;
        return person ?? throw new Exception($"Not found any PERSON with this ID  -  {id}");
    }

    public async Task<bool> UpdateAsync(Person person)
    {
        using var db = new SqlConnection(_connectionString);
        var result = await db.ExecuteAsync("UPDATE [dbo].[Persons] SET [Name] = @Name, [Surname] = @Surname, [Age] = @Age, [Birthday] = @Birthday, [Gender] = @Gender  Where [Id] = @Id", new
        {
            person.Id,
            person.Name,
            person.Surname,
            person.Birthday,
            person.Gender,
            person.Age
        });
        return result == 1;
    }
}
