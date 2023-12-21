namespace CleanArch.Tests.Commons;

internal abstract class BuilderBase<T> where T : class
{
    public abstract T Build();
}


