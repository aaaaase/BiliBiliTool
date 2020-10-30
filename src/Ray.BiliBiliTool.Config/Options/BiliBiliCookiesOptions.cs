﻿using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Ray.BiliBiliTool.Infrastructure.Extensions;

namespace Ray.BiliBiliTool.Config.Options
{
    public class BiliBiliCookiesOptions
    {
        [Description("DedeUserID")]
        public string UserId { get; set; }

        [Description("SESSDATA")]
        public string SessData { get; set; }

        [Description("bili_jct")]
        public string BiliJct { get; set; }

        public bool Check(ILogger logger)
        {
            bool result = true;
            string msg = "配置[{0}]为空,该项为必须配置,对应浏览器中Cookie中的[{1}]值";

            if (string.IsNullOrWhiteSpace(UserId))
            {
                logger.LogWarning(msg, nameof(UserId), GetPropertyDescription(nameof(UserId)));
                result = false;
            }
            if (string.IsNullOrWhiteSpace(SessData))
            {
                logger.LogWarning(msg, nameof(SessData), GetPropertyDescription(nameof(SessData)));
                result = false;
            }
            if (string.IsNullOrWhiteSpace(BiliJct))
            {
                logger.LogWarning(msg, nameof(BiliJct), GetPropertyDescription(nameof(BiliJct)));
                result = false;
            }

            return result;
        }


        public override string ToString()
        {
            return $"{GetPropertyDescription(nameof(BiliJct))}={BiliJct};{GetPropertyDescription(nameof(SessData))}={SessData};{GetPropertyDescription(nameof(UserId))}={UserId}";
        }

        private string GetPropertyDescription(string propertyName)
        {
            return GetType().GetPropertyDescription(propertyName);
        }
    }
}
