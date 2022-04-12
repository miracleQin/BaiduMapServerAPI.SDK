using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点检索详情信息
    /// </summary>
    public class SearchResultItemDetail
    {
        /// <summary>
        /// 距离中心点的距离
        /// <para>圆形区域检索时返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }
        /// <summary>
        /// 所属分类
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]        
        public string Type { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }
        /// <summary>
        /// POI对应的导航引导点坐标
        /// <para>大型面状POI的导航引导点，一般为各类出入口，方便结合导航、路线规划等服务使用</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("navi_location")]
        public Models.Location NaviLocation { get; set; }
        /// <summary>
        /// POI 地址信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// poi别名
        /// </summary>
        [Newtonsoft.Json.JsonProperty("alias")]
        public List<string> Alias { get; set; }
        /// <summary>
        /// poi的详情页
        /// </summary>
        [Newtonsoft.Json.JsonProperty("detail_url")]
        public string DetailUrl { get; set; }
        /// <summary>
        /// POI 地址信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("children")]
        public List<SearchResultItemDetailChild> Children { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("shop_hours")]
        public string ShopHours { get; set; }
        /// <summary>
        /// 总体评分
        /// </summary>
        [Newtonsoft.Json.JsonProperty("overall_rating")]
        public string OverallRating { get; set; }
        /// <summary>
        /// 口味评分
        /// </summary>
        [Newtonsoft.Json.JsonProperty("taste_rating")]
        public string TasteRating { get; set; }
        /// <summary>
        /// 服务评分
        /// </summary>
        [Newtonsoft.Json.JsonProperty("service_rating")]
        public string ServiceRating { get; set; }
        /// <summary>
        /// 环境评分
        /// </summary>
        [Newtonsoft.Json.JsonProperty("environment_rating")]
        public string EnvironmentRating { get; set; }
        /// <summary>
        /// 星级（设备）评分
        /// </summary>
        [Newtonsoft.Json.JsonProperty("facility_rating")]
        public string FacilityRating { get; set; }
        /// <summary>
        /// 卫生评分
        /// </summary>
        [Newtonsoft.Json.JsonProperty("hygiene_rating")]
        public string HygieneRating { get; set; }
        /// <summary>
        /// 技术评分
        /// </summary>
        [Newtonsoft.Json.JsonProperty("technology_rating")]
        public string TechnologyRating { get; set; }
        /// <summary>
        /// 图片数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("image_num")]
        public int? ImageNum { get; set; }
        /// <summary>
        /// 团购数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("groupon_num")]
        public int? GrouponNum { get; set; }
        /// <summary>
        /// 优惠数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("discount_num")]
        public int? DiscountNum { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("comment_num")]
        public int? CommentNum { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("favorite_num")]
        public int? FavoriteNum { get; set; }
        /// <summary>
        /// 签到数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("checkin_num")]
        public int? CheckinNum { get; set; }
        /// <summary>
        /// poi对应的品牌
        /// <para>如加油站中的『中石油』、『中石化』</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("brand")]
        public string Brand { get; set; }
        /// <summary>
        /// poi标签信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("content_tag")]
        public string ContentTag { get; set; }
    }

    /// <summary>
    /// POI 地址信息
    /// </summary>
    public class SearchResultItemDetailChild 
    {
        /// <summary>
        /// poi子点的唯一标示，可用于详情检索
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public string UID { get; set; }

        /// <summary>
        /// poi子点名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// poi子点简要名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("show_name")]
        public string ShowName { get; set; }

        /// <summary>
        /// poi子点类别
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// poi子点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.Location Location { get; set; }
        /// <summary>
        /// poi子点地址
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// poi商户的价格
        /// </summary>
        [Newtonsoft.Json.JsonProperty("price")]
        public string Price { get; set; }
    }
}
