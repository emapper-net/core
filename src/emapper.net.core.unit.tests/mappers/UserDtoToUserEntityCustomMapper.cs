using System;

using emapper.net.unit.tests.model;

namespace emapper.net.unit.tests.mappers;

public class UserDtoToUserEntityCustomMapper : ICustomMapper<UserDto, UserEntity>
{
    private readonly static char[] sepChars = new char[] { ' ', ',', '\t', '.' };


    private static string GetFirstName(string fullName)
    {
        var idx = fullName.IndexOfAny(sepChars);
        if (idx == -1)
        {
            return fullName;
        }
        else
        {
            return fullName.Substring(0, idx);
        }
    }

    private static string GetLastName(string fullName)
    {
        var idx = fullName.LastIndexOfAny(sepChars);
        if (idx == -1)
        {
            return "";
        }
        else
        {
            return fullName.Substring(idx + 1, fullName.Length - idx);
        }
    }

    private static string GatMiddleName(string fullName)
    {
        var firstIdx = fullName.IndexOfAny(sepChars);
        var lastIdx = fullName.LastIndexOfAny(sepChars);
        if (firstIdx == -1 || firstIdx == lastIdx)
        {
            return "";
        }
        else
        {
            return fullName.Substring(firstIdx + 1, lastIdx - firstIdx - 1);
        }
    }

    public UserEntity Map(UserDto source)
    {
        return new UserEntity(source.Id, source.Email, GetFirstName(source.FullName),
            GatMiddleName(source.FullName), GetLastName(source.FullName));
    }
}