﻿namespace Xuesky.Common.Models
{
    public class ReceiveBase
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
        public string MsgId { get; set; }
    }
}
