# BaiduMapAPISDK

[百度地图服务端 API](https://lbs.baidu.com/index.php?title=webapi)

该项目主要是因为要跟百度地图做对接时，想要更方便些去直接使用百度地图的接口，故而诞生此项目。

## 调用方法

1. 根据SDK命名空间划分接口的使用。目前主要在 'BaiduMapAPI.APIs' 下
2. 接口实体使用方式：

```

string AK = "********";//你在百度开放平台上的应用ak
string SK = "********";//你在百度开放平台上的应用sk

BaiduMapAPI.APIs.Place.V2.SearchByRegion search = new BaiduMapAPI.APIs.Place.V2.SearchByRegion()
{
    Region = "南宁",
    Query = "超市"
};

var result = search.GetResult(AK, SK);


```

## 命名空间与百度地图接口关系

序号 | 命名空间 | 实现接口文档
:--: | :-- | :--: 
01 | BaiduMapAPI.APIs.AddressAnalyzer | [地址解析聚合](https://lbsyun.baidu.com/index.php?title=webapi/address_analyze)
02 | BaiduMapAPI.APIs.Direction | [路线规划服务](https://lbsyun.baidu.com/index.php?title=webapi/direction-api-v2)
03 | BaiduMapAPI.APIs.DirectionLite | [轻量级路线规划服务](https://lbsyun.baidu.com/index.php?title=webapi/directionlite-v1)
04 | BaiduMapAPI.APIs.Geocoding | [地理编码服务](https://lbsyun.baidu.com/index.php?title=webapi/guide/webservice-geocoding)
05 | BaiduMapAPI.APIs.Geoconv | [坐标转换服务](https://lbsyun.baidu.com/index.php?title=webapi/guide/changeposition)
06 | BaiduMapAPI.APIs.Location | [普通IP定位](https://lbsyun.baidu.com/index.php?title=webapi/ip-api)
07 | BaiduMapAPI.APIs.LogisticsDirection | [物流路线规划服务](https://lbsyun.baidu.com/index.php?title=webapi/direction-api-truck)
08 | BaiduMapAPI.APIs.LogisticsRoutematrix | [物流批量算路](https://lbsyun.baidu.com/index.php?title=webapi/route-matrix-truck)
09 | BaiduMapAPI.APIs.Parking | [推荐上车点服务](https://lbsyun.baidu.com/index.php?title=webapi/parking-api)
10 | BaiduMapAPI.APIs.Place | [地点输入提示服务](https://lbsyun.baidu.com/index.php?title=webapi/place-suggestion-api)、[地点检索服务](https://lbsyun.baidu.com/index.php?title=webapi/guide/webservice-placeapi)
11 | BaiduMapAPI.APIs.RecogAddress | [地址城乡类型判别](https://lbsyun.baidu.com/index.php?title=webapi/address_recognize)
12 | BaiduMapAPI.APIs.RegionSearch | [行政区划查询服务](https://lbsyun.baidu.com/index.php?title=webapi/district-search)
13 | BaiduMapAPI.APIs.ReverseGeocoding | [全球逆地理编码服务](https://lbsyun.baidu.com/index.php?title=webapi/guide/webservice-geocoding-abroad)
14 | BaiduMapAPI.APIs.Ros | [智能调度路网矩阵服务](https://lbsyun.baidu.com/index.php?title=webapi/ROS1)、[智能调度排单排线服务](https://lbsyun.baidu.com/index.php?title=webapi/ROS2)、[智能调度快速排单服务](https://lbsyun.baidu.com/index.php?title=webapi/ROS3)、[智能调度多仓排单服务](https://lbsyun.baidu.com/index.php?title=webapi/ROS4)
15 | BaiduMapAPI.APIs.Routematrix | [批量算路服务](https://lbsyun.baidu.com/index.php?title=webapi/route-matrix-api-v2)
16 | BaiduMapAPI.APIs.Staticimage | [百度地图静态图API](https://lbsyun.baidu.com/index.php?title=static)
17 | BaiduMapAPI.APIs.TimeZone | [时区服务](https://lbsyun.baidu.com/index.php?title=webapi/guide/timezone)
18 | BaiduMapAPI.APIs.Track | [轨迹纠偏服务](https://lbsyun.baidu.com/index.php?title=webapi/guide/trackrectify)、[轨迹重合率分析服务](https://lbsyun.baidu.com/index.php?title=webapi/guide/trackmatch)
19 | BaiduMapAPI.APIs.Traffic | [实时路况查询服务](https://lbsyun.baidu.com/index.php?title=webapi/traffic)
20 | BaiduMapAPI.APIs.Weather | [国内天气查询服务](https://lbsyun.baidu.com/index.php?title=webapi/weather)
21 | BaiduMapAPI.APIs.WeatherAbroad | [海外天气查询服务](https://lbsyun.baidu.com/index.php?title=webapi/weather-abroad)
22 | BaiduMapAPI.YingYan.V3.Entity | [鹰眼-终端管理](http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/entity)、[鹰眼-空间搜索](http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/entitysearch)
23 | BaiduMapAPI.YingYan.V3.Track | [鹰眼-轨迹上传](http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/trackupload)、[鹰眼-轨迹查询和纠偏](http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/trackprocess)
24 | BaiduMapAPI.YingYan.V3.Analysis | [鹰眼-轨迹分析](https://lbsyun.baidu.com/index.php?title=yingyan/api/v3/analysis)
25 | BaiduMapAPI.YingYan.V3.FrequentRoute | [鹰眼-经验行为分析](https://lbsyun.baidu.com/index.php?title=yingyan/api/v3/empiricalbehavior)