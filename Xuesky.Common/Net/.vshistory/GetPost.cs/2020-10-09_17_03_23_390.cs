using System.Net.Http;
using System.Threading.Tasks;

namespace Xuesky.Common.Net
{
    public class GetPost
    {
        public void Get()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage result = client.GetAsync("http://www.weather.com.cn/data/sk/101110101.html").Result;
            Task<string> re = result.Content.ReadAsStringAsync();
        }
        public void Post()
        {
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent("123123");
            var result = client.PostAsync("http://www.baidu.com", content).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
