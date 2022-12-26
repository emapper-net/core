using System;
namespace emapper.net.unit.tests.model;

public class PersonName
{
    public PersonName(string firstName, string middleName, string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    public string FirstName { get; }

    public string MiddleName { get; }

    public string LastName { get; }
}