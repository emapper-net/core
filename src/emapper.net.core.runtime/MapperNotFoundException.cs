using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace emapper.net;

[Serializable]
[ExcludeFromCodeCoverage]
public class MapperNotFoundException : Exception
{
    public MapperNotFoundException() : base()
    {
    }

    public MapperNotFoundException(string message)
        : base(message)
    {
    }

    protected MapperNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}