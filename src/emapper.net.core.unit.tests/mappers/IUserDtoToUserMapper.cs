using System;

using emapper.net.unit.tests.model;

namespace emapper.net.unit.tests.mappers;

[Mapper(typeof(UserDto), typeof(UserEntity))]
public interface IUserDtoToUserEntityMapper
{
}