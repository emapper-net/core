using System;
namespace emapper.net;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class MapAttribute : Attribute
{
    public string? Target { get; set; } = null;

    public Type? Using { get; set; } = null;

    public string? WithExpression { get; set; } = null;
}