using System.Buffers.Text;
using System.Text;

namespace OneInc.Server.Services
{
    public class StringConvertToBase64Service : IStringConvertService<string>
    {
        public string Convert(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return System.Convert.ToBase64String(bytes);
        }
    }
}
