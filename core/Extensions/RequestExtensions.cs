using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace core.Extensions
{
    public static class RequestExtensions
    {
        public static async Task<T> ReadAs<T>(this HttpContent message)
        {
            return JsonConvert.DeserializeObject<T>(await message.ReadAsStringAsync());
        }
    }
}