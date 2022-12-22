using System;
namespace emapper.net.unit.tests.model;

public class UserEntity
{
    public UserEntity(string id, string email, string firstName, string middleName, string lastName)
    {
        Id = id;
        Email = email;
        Name = new PersonName(firstName, middleName, lastName);
    }

    public string Id { get; }
    public string Email { get; }
    public PersonName Name { get; }
}