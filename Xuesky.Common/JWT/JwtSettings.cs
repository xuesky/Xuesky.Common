using System;
using System.Collections.Generic;
using System.Text;

namespace Xuesky.Common.JWT
{
    public static class JwtSettings
    {
        /// <summary>
        /// 发行者
        /// </summary>
        public static string Issuer => "http://localhost";
        /// <summary>
        /// 订阅者
        /// </summary>
        public static string Audience => "http://localhost";
        /// <summary>
        /// Key
        /// </summary>
        public static string SecrectKey => "xue88sky.abc.$$$$";
    }
}
