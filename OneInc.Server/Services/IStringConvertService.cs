namespace OneInc.Server.Services
{
    public interface IStringConvertService<T> where T : class
    {
        Task<T> Convert(T value);
    }
}
