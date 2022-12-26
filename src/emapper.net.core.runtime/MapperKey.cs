using System;
namespace emapper.net;

internal record class MapperKey
{
    public MapperKey(Type source, Type target)
    {
        Source = source;
        Target = target;
    }

    public Type Source { get; private set; }

    public Type Target { get; private set; }


    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Source.GetHashCode();
        hash = hash * 23 + Target.GetHashCode();
        return hash;
    }
}