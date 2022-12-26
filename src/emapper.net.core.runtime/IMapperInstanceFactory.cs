using System;
namespace emapper.net;

public interface ICustomMapper<TSource, TTarget>
{
    TTarget Map(TSource source);
}