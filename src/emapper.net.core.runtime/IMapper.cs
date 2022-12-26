using System;
namespace emapper.net;

public interface IMapper<TSource, TTarget> : IMapperDescriptor
{
    public TTarget Map(TSource source);
}