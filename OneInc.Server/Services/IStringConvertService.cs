namespace OneInc.Server.Services
{
    public interface IStringConvertService<T> where T : class
    {
        T Convert(T value);
    }
}
