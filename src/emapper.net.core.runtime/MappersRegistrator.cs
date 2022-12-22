using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

namespace emapper.net;

internal static class MappersRegistrator
{
    private static bool IsMapperInstance(Type type) => (type.IsClass && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapper<,>)));

    public static void Register(IServiceCollection services)
    {
        IEnumerable<Type> types = TypeScanner.Find(type => IsMapperInstance(type));
        foreach (Type mapperType in types)
        {
            var instance = Activator.CreateInstance(mapperType) as IMapperDescriptor;
            if (instance == null)
            {
                throw new NotSupportedException("Instance could not be created or casted to IMapperDescriptor");
            }

            MappersService.Register(instance);

            var genericMapperType = typeof(IMapper<,>).MakeGenericType(instance.SourceType, instance.TargetType);
            services.AddSingleton(genericMapperType, instance);
        }
    }
}