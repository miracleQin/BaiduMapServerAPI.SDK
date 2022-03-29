using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 骑行路线规划
    /// </summary>
    public class RidingResult : Models.ResponseOld
    {
        /// <summary>
        /// 返回的结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public RidingResultResult Result { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("info")]
        public RidingResultInfo Info { get; set; }
    }

    public class RidingResultInfo
    {
        /// <summary>
        /// 版权信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("copyright")]
        public RidingResultCopyRight Copyright { get; set; }
    }

    public class RidingResultCopyRight
    {
        /// <summary>
        /// 版权文本
        /// </summary>
        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 版权图片链接
        /// </summary>
        [Newtonsoft.Json.JsonProperty("imageUrl")]
        public string ImageURL { get; set; }
    }

    public class RidingResultResult 
    {
        /// <summary>
        /// 起点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("origin")]
        public RidingResultOrigin Origin { get; set; }

        /// <summary>
        /// 终点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination")]
        public RidingResultDestination Destination { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<RidingResultRoute> Routes { get; set; }
    }

    public class RidingResultPointBase 
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("area_id")]
        public int? AreaID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("cname")]
        public string CName { get; set; }


        /// <summary>
        /// 地点编号
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public string UID { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wd")]
        public string WD { get; set; }

    }

    public class RidingResultOrigin : RidingResultPointBase
    {
        /// <summary>
        /// 起点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("originPt")]
        public Models.Location OriginPt { get; set; }
    }

    public class RidingResultDestination : RidingResultPointBase
    {
        /// <summary>
        /// 终点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destinationPt")]
        public Models.Location DestinationPt { get; set; }
    }

    public class RidingResultRoute
    {
        /// <summary>
        /// 方案距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 线路耗时
        /// <para>单位：秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }


        /// <summary>
        /// 路线起点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("originLocation")]
        public Models.Location OriginLocation { get; set; }

        /// <summary>
        /// 路线终点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destinationLocation")]
        public Models.Location DestinationLocation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("steps")]
        public List<RidingResultStep> Steps { get; set; }
    }

    public class RidingResultStep 
    {
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("area")]
        public int? Area { get; set; }

        /// <summary>
        /// 当前道路方向角
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public int? Direction { get; set; }

        /// <summary>
        /// 路段距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 路段耗时
        /// <para>单位：秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 路段描述
        /// <para>如“骑行50米“</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// 该路段道路名称
        /// <para>如“信息路“</para>
        /// <para>若道路未命名或百度地图未采集到该道路名称，则返回"无名路"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 该路段道路的关键点坐标
        /// <para>坐标系由ret_coordtype设置，示例：</para>
        /// <para>“116.321858,40.039183;116.3216343,40.039141”</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("path")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.LocationListConverter))]
        public List<Models.Location> Path { get; set; }


        /// <summary>
        /// 行驶转向方向
        /// <para>如“直行”、“左前方转弯”</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("turn_type")]
        public string TurnType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public int? Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("restrictions_info")]
        public string RestrictionsInfo { get; set; }

        /// <summary>
        /// 路段起点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stepOriginLocation")]
        public Models.Location StepOriginLocation { get; set; }

        /// <summary>
        /// 路段起点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stepDestinationLocation")]
        public Models.Location StepDestinationLocation { get; set; }

        /// <summary>
        /// 起点说明
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stepOriginInstruction")]
        public string StepOriginInstruction { get; set; }

        /// <summary>
        /// 终端说明
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stepDestinationInstruction")]
        public string StepDestinationInstruction { get; set; }
    }
}
