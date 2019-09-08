using System;
using System.Security.Cryptography;
using System.Text;

namespace Xuesky.Common.Security
{
    public class SecurityHelper
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public SecurityHelper()
        {
            var md5 = MD5.Create();
            //var result = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes("2969QcjAbppds0k=1559814561"))).Replace("-", "");
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes("2969QcjAbppds0k=1560327511"));

            var result1 = Convert.ToBase64String(result);
        }
    }
}
