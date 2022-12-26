using System;
namespace emapper.net;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
public class MapperAttribute : Attribute
{
    public MapperAttribute(Type sourceType, Type destinationType)
    {
        this.SourceType = sourceType;
        this.DestinationType = destinationType;
    }

    public Type SourceType { get; private set; }

    public Type DestinationType { get; private set; }
}