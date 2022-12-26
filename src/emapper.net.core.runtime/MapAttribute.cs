using System;
namespace emapper.net;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class MapAttribute : Attribute
{
    public Type? Using { get; set; } = null;

}