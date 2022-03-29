using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Location
{
    /// <summary>
    /// 普通IP定位结果
    /// </summary>
    public class IPResult : Models.ResponseOld
    {
        public class IPResultContent 
        {
            /// <summary>
            /// 简要地址信息
            /// </summary>
            [Newtonsoft.Json.JsonProperty("address")]
            public string Address { get; set; }

            /// <summary>
            /// 地址详情
            /// </summary>

            [Newtonsoft.Json.JsonProperty("address_detail")]
            public IPResultAddressDetail AddressDetail { get; set; }
            /// <summary>
            /// 坐标
            /// </summary>

            [Newtonsoft.Json.JsonProperty("point")]
            public Models.Point Point { get; set; }
        }

        public class IPResultAddressDetail 
        {
            /// <summary>
            /// 城市
            /// </summary>
            [Newtonsoft.Json.JsonProperty("city")]
            public string City { get; set; }
            /// <summary>
            /// 百度城市代码
            /// </summary>

            [Newtonsoft.Json.JsonProperty("city_code")]
            public string CityCode { get; set; }
            /// <summary>
            /// 	省份
            /// </summary>

            [Newtonsoft.Json.JsonProperty("province")]
            public string province { get; set; }
        }


        /// <summary>
        /// 详细地址信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 地址内容
        /// </summary>
        [Newtonsoft.Json.JsonProperty("content")]
        public IPResultContent Content { get; set; }

    }
}
