using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.APIs.Staticimage.V2
{
    /// <summary>
    /// 静态地图
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/staticimage/v2";

        /// <summary>
        /// 安全码
        /// <para>若为Android/IOS SDK的ak, 该参数必需</para>
        /// </summary>
        [Display(Name = "mcode")]
        public string MCode { get; set; }

        /// <summary>
        /// 图片宽度
        /// <para>取值范围：(0, 1024]</para>
        /// <para>Scale=2,取值范围：(0, 512]</para>
        /// </summary>
        [Display(Name = "width")]
        public int? Width { get; set; }

        /// <summary>
        /// 图片高度
        /// <para>取值范围：(0, 1024]</para>
        /// <para>Scale=2,取值范围：(0, 512]</para>
        /// </summary>
        [Display(Name = "height")]
        public int? Height { get; set; }

        /// <summary>
        /// 地图中心点位置
        /// <para>参数可以为经纬度坐标或名称</para>
        /// </summary>
        [Display(Name = "center")]
        public Center Center { get; set; }

        /// <summary>
        /// 地图级别
        /// <para>高清图范围[3, 18]；低清图范围[3,19]</para>
        /// </summary>
        [Display(Name = "zoom")]
        public int? Zoom { get; set; }

        /// <summary>
        /// 静态图版权样式
        /// </summary>
        [Display(Name = "copyright")]
        [EnumValue]
        public CopyrightStyle? Copyright { get; set; }

        /// <summary>
        /// 手机屏幕类型
        /// <para>高分屏即调用高清地图，低分屏为普通地图</para>
        /// </summary>
        [Display(Name = "dpiType")]
        [EnumValue]
        public DpiType? DpiType { get; set; }

        /// <summary>
        /// 静态图的坐标类型
        /// <para>支持wgs84ll（wgs84坐标）/gcj02ll（国测局坐标）/bd09ll（百度经纬度）/bd09mc（百度墨卡托）</para>
        /// </summary>
        [Display(Name = "coordtype")]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 返回图片大小会根据此标志调整
        /// <para>注：如果zoom为最大级别，则返回图片为（width*2）*（height*2），zoom不变。</para>
        /// </summary>
        [Display(Name = "scale")]
        public Scale? Scale { get; set; }

        /// <summary>
        /// 地图视野范围
        /// </summary>
        [Display(Name = "bbox")]
        public BBox BBox { get; set; }

        /// <summary>
        /// 标注
        /// <para>可通过经纬度或地址/地名描述</para>
        /// <para>多个标注之间用竖线分隔</para>
        /// </summary>
        [Display(Name = "markers")]
        [ListObjectConverter]
        public List<Center> Markers { get; set; }

        /// <summary>
        /// 标注样式
        /// <para>与markers有对应关系</para>
        /// <para>markerStyles可设置默认图标样式和自定义图标样式。其中设置默认图标样式时，可指定的属性包括size,label和color；设置自定义图标时，可指定的属性包括url，注意，设置自定义图标时需要先传-1以此区分默认图标。</para>
        /// </summary>
        [Display(Name = "markerStyles")]
        [ListObjectConverter]
        public List<MarkerStyle> MarkerStyles { get; set; }

        /// <summary>
        /// 标签
        /// <para>可通过经纬度或地址/地名描述</para>
        /// <para>多个标注之间用竖线分隔</para>
        /// </summary>
        [Display(Name = "labels")]
        [ListObjectConverter]
        public List<Center> Labels { get; set; }

        /// <summary>
        /// 标签的样式
        /// <para>与labels一一对应。</para>
        /// </summary>
        [Display(Name = "lableStyles")]
        [ListObjectConverter]
        public List<LabelStyle> LabelStyles { get; set; }

        /// <summary>
        /// 折线
        /// <para>可通过经纬度或地址/地名描述</para>
        /// <para>多个标注之间用竖线分隔</para>
        /// </summary>
        [Display(Name = "paths")]
        [ListObjectConverter]
        public List<Center> Paths { get; set; }

        /// <summary>
        /// 折线样式
        /// </summary>
        [Display(Name = "pathStyles")]
        [ListObjectConverter]
        public List<PathStyle> PathStyles { get; set; }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="AK"></param>
        /// <param name="SK"></param>
        /// <returns></returns>
        public override async Task<GetResult> GetResultAsync(string AK, string SK)
        {
            string url = "";

            await Task.Run(() =>
            {
                NameValueCollection querys = this.GetPropertyStringValue();
                querys.Add("ak", AK);
                url = BaiduHelper.GetSNUrl(this.URL, AK, SK, querys, false);
            });

            return new V2.GetResult() { ImageURL = url };
        }
    }

    /// <summary>
    /// 中心点信息
    /// </summary>
    public class Center : Models.Location
    {
        /// <summary>
        /// 中心点信息
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        public Center(double lat, double lng) : base(lat, lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }

        /// <summary>
        /// 中心点信息
        /// </summary>
        /// <param name="name">地址名称</param>
        public Center(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// 地址名称
        /// <para>若填了坐标信息，优先启用坐标信息</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this.Lat.HasValue && this.Lng.HasValue) ? $"{Lng},{Lat}" : BaiduHelper.UrlEncode(this.Name);
        }
    }

    /// <summary>
    /// 静态图版权样式
    /// </summary>
    public enum CopyrightStyle
    {
        /// <summary>
        /// log+文字描述
        /// </summary>
        [Description("logo和文字")]
        LogoAndText = 0,
        /// <summary>
        /// 纯文本
        /// </summary>
        [Description("纯文字")]
        Text = 1,
    }

    /// <summary>
    /// 手机屏幕类型
    /// </summary>
    public enum DpiType
    {
        /// <summary>
        /// 高分屏
        /// </summary>
        [Description("高分屏")]
        ph = 0,

        /// <summary>
        /// 低分屏
        /// </summary>
        [Description("低分屏")]
        pl = 1,
    }

    /// <summary>
    /// 比例类型
    /// </summary>
    public enum Scale
    {
        /// <summary>
        /// 小
        /// <para>返回的图片大小为size= width * height</para>
        /// </summary>
        [Description("小")]
        Small = 1,
        /// <summary>
        /// 大
        /// <para>返回图片为(width*2)*(height *2)，且zoom加1</para>
        /// </summary>
        [Description("大")]
        Big = 2,
    }

    /// <summary>
    /// 地图视野范围
    /// </summary>
    public class BBox
    {
        /// <summary>
        /// 
        /// </summary>
        public double? MinX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? MinY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? MaxX { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? MaxY { get; set; }

        /// <summary>
        /// 转成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{MinX},{MinY};{MaxX},{MaxY}";
        }
    }

    /// <summary>
    /// 标注样式
    /// </summary>
    public class MarkerStyle
    {
        /// <summary>
        /// 尺寸
        /// </summary>
        public MarkerStyleSize? Size { get; set; }

        /// <summary>
        /// 文本
        /// <para>可以为[0-9]、[A-Z]，不指定时显示A。</para>
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public System.Drawing.Color? Color { get; set; }

        /// <summary>
        /// 自定义icon的地址
        /// <para>图片格式目前仅支持png32的</para>
        /// <para>设置自定义图标标注时，忽略以上三个属性，只设置该属性且该属性前增加-1,如 markerStyles=-1,https://api.map.baidu.com/images/marker_red.png</para>
        /// <para>图标大小需小于5k，超过该值会导致加载不上图标的情况发生,图标的尺寸应小于256*256</para>
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// 转字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = null;

            if (!string.IsNullOrEmpty(URL))
            {
                result = $"-1,{URL}";
            }
            else
            {
                List<string> infos = new List<string>();

                var sizeType = typeof(MarkerStyleSize);

                if (Size.HasValue)
                {
                    var field = sizeType.GetField(Size.ToString());
                    var customDescription = field.GetCustomAttribute<CustomDescriptionAttribute>();
                    infos.Add(customDescription.Value.ToString());
                }
                if (!string.IsNullOrEmpty(Label)) infos.Add(Label);

                if (Color.HasValue)
                {
                    infos.Add(Color.ToCss());
                }
                result = string.Join(",", infos);
            }

            return result;
        }
    }


    /// <summary>
    /// 标注样式尺寸
    /// </summary>
    public enum MarkerStyleSize
    {
        /// <summary>
        /// 小
        /// </summary>
        [CustomDescription("小", "s")]
        Small = 0,

        /// <summary>
        /// 中
        /// </summary>
        [CustomDescription("中", ",m")]
        Middle = 1,

        /// <summary>
        /// 大
        /// </summary>
        [CustomDescription("大", "l")]
        Large = 2,
    }

    /// <summary>
    /// 标签样式
    /// </summary>
    public class LabelStyle
    {
        /// <summary>
        /// 标签内容
        /// <para>中文字符需要用encodeURIComponent编码。允许16个字符。</para>
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 设置label是否有边框
        /// <para>0表示无边框（暂不支持），1表示有边框。</para>
        /// </summary>
        public bool? Border { get; set; }

        /// <summary>
        /// 字体大小
        /// <para>0为默认大小；取值范围在(0,96)。</para>
        /// </summary>
        public int? FontSize { get; set; }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public System.Drawing.Color? FontColor { get; set; }

        /// <summary>
        /// 标签背景颜色
        /// </summary>
        public System.Drawing.Color? BgColor { get; set; }

        /// <summary>
        /// 设置字体是否是粗体
        /// <para>0表示非粗体（暂不支持），1表示粗体。</para>
        /// </summary>
        public bool? FontWeight { get; set; }

        /// <summary>
        /// 转成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{BaiduHelper.UrlEncode(Content)},{(Border == true ? "1" : "0")},{FontSize},{FontColor.ToCss()},{BgColor.ToCss()},{(FontWeight == true ? "1" : "0")}";
        }
    }

    /// <summary>
    /// 折线样式
    /// </summary>
    public class PathStyle
    {
        /// <summary>
        /// 折线颜色
        /// </summary>
        public System.Drawing.Color? Color { get; set; }

        /// <summary>
        /// 折线粗细
        /// <para>3到32之间的正整数。</para>
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// 折线或者面的透明度
        /// <para>0，1之间的一个小数。</para>
        /// </summary>
        public double? Opacity { get; set; }

        /// <summary>
        /// 填充颜色
        /// <para>可选参数!注意!：如果设置了填充颜色则折线自动闭合为多边形。</para>
        /// </summary>
        public System.Drawing.Color? FillColor { get; set; }

        /// <summary>
        /// 转成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FillColor.HasValue ? $"{Color.ToCss()},{Weight},{Opacity},{FillColor.ToCss()}" : $"{Color.ToCss()},{Weight},{Opacity}";
        }
    }
}
