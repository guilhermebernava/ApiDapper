namespace Domain.Entities;

public class Person
{
    public Person()
    {
        
    }
    public Person(string name, string surname, int age, string gender, DateTime birthday)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Age = age;
        Gender = gender;
        Birthday = birthday;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public DateTime Birthday { get; set; }
}
