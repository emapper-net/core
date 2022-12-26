using System;

using emapper.net.unit.tests.model;

namespace emapper.net.unit.test.mappers;

[Mapper(typeof(UserEntity), typeof(UserDto))]
public interface IUseEntityToUserDtoMapper
{
}