using System.Collections.Concurrent;

namespace emapper.net;

public static class MappersService
{
    private static readonly ConcurrentDictionary<MapperKey, IMapperDescriptor> mappers = new();

    internal static void Register(IMapperDescriptor value) => mappers[new MapperKey(value.SourceType, value.TargetType)] = value;

    public static void Register<TSource, TTarget>(IMapper<TSource, TTarget> value) => mappers[new MapperKey(typeof(TSource), typeof(TTarget))] = value;

    public static IMapper<TSource, TTarget>? GetMapper<TSource, TTarget>() => (IMapper<TSource, TTarget>)mappers[new MapperKey(typeof(TSource), typeof(TTarget))];

    public static TTarget Map<TSource, TTarget>(TSource value)
    {
        var mapper = GetMapper<TSource, TTarget>();
        if (mapper == null)
        {
            throw new MapperNotFoundException($"No mapper registered to convert {typeof(TSource)} to {typeof(TTarget)}");
        }

        return mapper.Map(value);
    }
}