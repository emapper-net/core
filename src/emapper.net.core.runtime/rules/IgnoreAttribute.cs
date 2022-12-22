using System;
namespace emapper.net.rules;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class IgnoreAttribute : Attribute
{

    public IgnoreAttribute(string property)
    {
        this.Property = property;
    }

    public string Property { get; private set; }
}