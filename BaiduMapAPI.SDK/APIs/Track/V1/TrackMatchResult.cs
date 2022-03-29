using BaiduMapAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Track.V1
{
    /// <summary>
    /// 轨迹重合率分析
    /// </summary>
    public class TrackMatchResult : Models.ResponseOld
    {
        /// <summary>
        /// 分析结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("data")]
        public TrackMatchResultData Data { get; set; }
    }

    public class TrackMatchResultData
    {
        /// <summary>
        /// 两条轨迹的匹配率
        /// <para>轨迹的相似度，取值范围[0,100]，值越大代表相似度越高</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("similarity")]
        public double? Similarity { get; set; }

        /// <summary>
        /// 匹配的轨迹里程
        /// <para>track和standard_track轨迹重合的里程</para>
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("matched_distance")]
        public double? MatchedDistance { get; set; }

        /// <summary>
        /// 偏离基准轨迹的里程
        /// <para>unmatched_distance=processed_track_distance-matched_distance</para>
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("unmatched_distance")]
        public double? UnmatchedDistance { get; set; }

        /// <summary>
        /// 纠偏后的基准轨迹
        /// <para>仅在填写了standard_option请求参数时返回该字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("processed_standard_track")]
        public List<TrackMatchResultProcessedStandardTrack> ProcessedStandardTrack { get; set; }

        /// <summary>
        /// 纠偏后的待匹配轨迹
        /// </summary>
        [Newtonsoft.Json.JsonProperty("processed_track")]
        public List<TrackMatchResultProcessedTrack> ProcessedTrack { get; set; }

        /// <summary>
        /// 原始基准轨迹的里程
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("standard_track_distance")]
        public double? StandardTrackDistance { get; set; }

        /// <summary>
        /// 原始待匹配轨迹的里程
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("track_distance")]
        public double? TrackDistance { get; set; }

        /// <summary>
        /// 纠偏后的基准轨迹里程
        /// <para>若请求参数未填写standard_option，则采用原始轨迹里程</para>
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("processed_standard_track_distance")]
        public double? ProcessedStandardTrackDistance { get; set; }

        /// <summary>
        /// 纠偏后的待匹配轨迹里程
        /// <para>若请求参数未填写option，则采用原始轨迹里程</para>
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("processed_track_distance")]
        public double? ProcessedTrackDistance { get; set; }
    }

    public class TrackMatchResultProcessedStandardTrack
    {
        /// <summary>
        /// 轨迹点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc")]
        public LocationDetail Location { get; set; }

        /// <summary>
        /// 定位时间
        /// <para>轨迹点的定位时间，使用UNIX时间戳</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? LocationTime { get; set; }

    }

    public class TrackMatchResultProcessedTrack : TrackMatchResultProcessedStandardTrack
    {
        /// <summary>
        /// 是否匹配
        /// <para>该轨迹点是否与processed_standard_track（若未填standard_option，则是standard_track）匹配。</para>
        /// <para>取值规则：</para>
        /// <para>匹配：则不返回该字段</para>
        /// <para>不匹配：值为1</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("unmatched")]
        public int? Unmatched { get; set; }
    }
}
