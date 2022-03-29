using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Parking
{
    /// <summary>
    /// 推荐上车点服务结果
    /// </summary>
    public class SearchResult : Models.ResponseOld
    {

        /// <summary>
        /// 推荐上下车点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("recommendstops")]
        public List<RecommendStop> RecommendStops { get; set; }
    }

    /// <summary>
    /// 推荐上车点信息
    /// </summary>
    public class RecommendStop
    {
        /// <summary>
        /// 推荐上下车点名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 距查找点的距离（m）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 推荐上车点经度（百度经纬度 bd09ll）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("baidu_x")]
        public double? BaiduX { get; set; }

        /// <summary>
        /// 推荐上车点纬度（百度经纬度 bd09ll）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("baidu_y")]
        public double? BaiduY { get; set; }

        /// <summary>
        /// 百度坐标(bd09ll)
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public Models.Location Baidu
        {
            get
            {
                if (baidu == null)
                    baidu = new Models.Location()
                    {
                        Lat = BaiduY,
                        Lng = BaiduX
                    };
                return baidu;
            }
        }
        private Models.Location baidu;

        /// <summary>
        /// 推荐上车点经度（国测局坐标系 gcj02ll）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gcj02ll_x")]
        public double? Gcj02llX { get; set; }

        /// <summary>
        /// 推荐上车点纬度（国测局坐标系 gcj02ll）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gcj02ll_y")]
        public double? Gcj02llY { get; set; }

        /// <summary>
        /// 国测局坐标 gcj02ll
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public Models.Location Gcj0211
        {
            get
            {
                if (gcj0211 == null)
                    gcj0211 = new Models.Location()
                    {
                        Lat = Gcj02llY,
                        Lng = Gcj02llX
                    };
                return gcj0211;
            }
        }

        private Models.Location gcj0211;
    }
}
