using System;
using System.Threading.Tasks;
using Xuesky.Common.Interface;

namespace Xuesky.Common.Delet
{
    public class Asynctest : ITest
    {
        public string GetName(int i) => $"aa";

        private int cacheResult;

        public async Task<int> LoadCache(int s)
        {
            // simulate async work:
            for (int i = 0; i < s; i++)
            {
                await Task.Delay(500);
                System.Console.WriteLine(i);
            }

            cacheResult = 100;
            return cacheResult;
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}