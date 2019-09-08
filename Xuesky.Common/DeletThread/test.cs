using System;
using System.Threading.Tasks;
using Xuesky.Common.Interface;

namespace Xuesky.Common.Delet
{
    public class Asynctest : ITest
    {
        public string GetName(int i) => $"aa";

        private int _cacheResult;

        public async Task<int> LoadCache(int s)
        {
            //simulate async work:
            for (int i = 0; i < s; i++)
            {
                await Task.Delay(500);
                System.Console.WriteLine(i);
            }

            _cacheResult = 100;
            return _cacheResult;
        }

        public async Task<string> GetUserInfo()
        {
            await Task.CompletedTask;
            return "";
        }
        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}