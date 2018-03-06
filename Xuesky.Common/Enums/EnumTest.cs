using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Omu.ValueInjecter.Utils;

namespace Xuesky.Common.Enums
{
    public class EnumTest
    {
        public EnumTest()
        {
            //把Select数据转换成枚举类型
            var enums = Enum.GetValues(typeof(PayType)).Cast<PayType>().Select(e => new SelectListItem { Text = e.ToString(),Value = ((int)Enum.Parse(typeof(PayType),e.ToString())).ToString()});
        }
    }
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayType
    {
        /// <summary>
        /// 微信
        /// </summary>
        [Description("支付宝")]
        WX = 1,

        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        ZB = 2
    }
}
