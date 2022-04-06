using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Matrix
{
    /// <summary>
    /// 路网创建接口
    /// </summary>
    public class Post : Models.JsonPostWithoutSN<PostResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v1/matrix";

        /// <summary>
        /// 路网矩阵名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 坐标类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locationType")]
        public Models.Enums.CoordType? LocationType { get; set; }

        /// <summary>
        /// 网点信息列表,包括仓库
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locations")]
        public List<PostLocation> Locations { get; set; }

        /// <summary>
        /// 客户可以根据自己场景填写
        /// </summary>
        [Newtonsoft.Json.JsonProperty("lbsType")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.FlagEnumConverter))]
        public Models.Enums.LbsType LbsType { get; set; }

        /// <summary>
        /// 路网初始化需要的车型信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleType")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.FlagEnumConverter))]
        public Models.Enums.RosMatrixVehicleType VehicleType { get; set; }
    }

    public class PostLocation : Models.LocationDetail
    {
        /// <summary>
        /// 客户网点的唯一key
        /// <para>排单排线需要用到, 长度最大32， 路网中不允许出现key相同的情况</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("key")]
        public string Key { get; set; }
    }
}
