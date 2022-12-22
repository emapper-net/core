using System;
namespace emapper.net.rules;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class UsingMappersServiceAttribute : Attribute
{
    public UsingMappersServiceAttribute(string from, string to)
    {
        this.From = from;
        this.To = to;
    }

    public string To { get; private set; }

    public string From { get; private set; }
}