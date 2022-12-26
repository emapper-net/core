using System;

using Microsoft.CodeAnalysis;

namespace emapper.net;

public class MapperDescriptor
{
    public MapperDescriptor(ISymbol symbol, TypeInfo sourceType, TypeInfo targetType)
    {
        this.Symbol = symbol;
        this.SourceType = sourceType;
        this.TargetType = targetType;
    }

    public ISymbol Symbol { get; }

    public TypeInfo SourceType { get; }

    public TypeInfo TargetType { get; }
}