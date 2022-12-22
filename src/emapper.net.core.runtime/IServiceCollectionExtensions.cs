using System;

using Microsoft.Extensions.DependencyInjection;

namespace emapper.net;

public static class ServiceColllectionExtensions
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        MappersRegistrator.Register(services);
        return services;
    }
}