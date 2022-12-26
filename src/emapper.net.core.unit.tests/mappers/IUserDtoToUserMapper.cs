using emapper.net.unit.tests.model;

namespace emapper.net.unit.tests.mappers;

[Mapper(typeof(UserDto), typeof(UserEntity))]
[Map(Using = typeof(UserDtoToUserEntityCustomMapper))]
public interface IUserDtoToUserEntityMapper
{
}