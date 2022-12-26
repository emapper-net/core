using System;
namespace emapper.net;

public interface IMapperDescriptor
{
    public Type SourceType { get; }

    public Type TargetType { get; }
}