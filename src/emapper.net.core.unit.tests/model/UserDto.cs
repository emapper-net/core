using System;
namespace emapper.net.unit.tests.model;

public record class UserDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string FullName { get; set; }
}