
using BiaduMap.TestConsoleApp.Linux;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class Test
{

    public static void TestWeather(string AK, string SK)
    {

        string id = "";
        Console.Write("请输入行政区代码:");
        id = Console.ReadLine() ?? "";

        BaiduMapAPI.APIs.Weather.V1.Get getWeather = new BaiduMapAPI.APIs.Weather.V1.Get()
        {
            DistrictID = id,
            DataType = BaiduMapAPI.APIs.Weather.V1.WeatherDataType.all,
        };

        var result = getWeather.GetResult(AK, SK);

        if (result.Status == 0)
        {
            if (result.Result != null)
            {
                Console.WriteLine($"{result.Result.Location?.Country}{result.Result.Location?.Province}{result.Result.Location?.City}{result.Result.Location?.Name}[{result.Result.Location?.ID}]\r\n");

                Console.WriteLine($"实时数据：");
                Console.WriteLine($"天气情况：{result.Result.Now?.Text}\t气温：{result.Result.Now?.Temperature}\t湿度：{result.Result.Now?.RelativeHumidity}");
                Console.WriteLine($"风力等级：{result.Result.Now?.WindClass}\t风向：{result.Result.Now?.WindDirection}\t数据更新时间：{result.Result.Now?.UpdatedAt:yyyy-MM-dd hh:mm:ss}");

                if (result.Result.ForeCasts != null)
                {
                    Console.WriteLine("七天天气预报：");
                    foreach (var forceCast in result.Result.ForeCasts)
                    {
                        Console.WriteLine($"{forceCast.Date:yyyy-MM-dd}[{forceCast.Week}] 最低 {forceCast.LowTemperature} ℃，最高 {forceCast.HighTemperature} ℃");
                        Console.WriteLine($"\t--日：{forceCast.TextDay} {forceCast.WindDirectionDay} {forceCast.WindClassDay}");
                        Console.WriteLine($"\t--夜：{forceCast.TextNight} {forceCast.WindDirectionNight} {forceCast.WindClassNight}");
                    }
                }
            }
        }
        else Console.WriteLine($"status:{result.Status}\tmessage:{result.Message}\terrMsg:{result.ErrMsg}");

        Console.ReadLine();
    }

    public static void TestRoutematrix(string AK)
    {

        BaiduMapAPI.APIs.Routematrix.V2.Driving driving = new BaiduMapAPI.APIs.Routematrix.V2.Driving()
        {
            Origins = new List<BaiduMapAPI.Models.Location>(),
            Destinations = new List<BaiduMapAPI.Models.Location>(),
        };

        do
        {
            Console.Write("请输入要添加的起点坐标信息(lng,lat):");
            var lca = Console.ReadLine();
            driving.Origins.Add(new BaiduMapAPI.Models.Location(lca));

            Console.Write("是否继续添加[Y/N]:");
        } while ((Console.ReadLine() + "").Equals("Y"));

        do
        {
            Console.Write("请输入要添加的终点坐标信息(lng,lat):");
            var lca = Console.ReadLine();
            driving.Destinations.Add(new BaiduMapAPI.Models.Location(lca));

            Console.Write("是否继续添加[Y/N]:");
        } while ((Console.ReadLine() + "").Equals("Y"));

        var drivingResult = driving.GetResult(AK);

        Console.WriteLine($"结果信息数量：[{drivingResult.Result?.Count}]");
    }

    [Display(ShortName = "add_analyze", Description = "测试地址解析聚合")]
    public static void TestAddressAnalyze(string AK, string SK)
    {
        Console.Write("请输入地址信息:");
        var addr = Console.ReadLine();

        BaiduMapAPI.APIs.AddressAnalyzer.V1.Get get = new BaiduMapAPI.APIs.AddressAnalyzer.V1.Get()
        {
            Address = addr
        };

        var getResult = get.GetResult(AK, SK);

        Console.WriteLine(getResult.Status + "  " + getResult.Message);
    }

    [Display(ShortName = "convert_cecog", Description = "测试转换地址城乡类型结果")]
    public static void TestConvertRecogJson()
    {
        string json = "{\"status\":0,\"admin_info\":{\"province\":\"北京市\",\"city\":\"北京市\",\"county\":\"海淀区\",\"town\":\"上地街道\"},\"admin_type\":{\"county_type\":\"区\",\"town_type\":\"街道\",\"town_urban_rural\":\"城市\",\"confidence\":100},\"stats_type\":{\"urban\":80,\"urban_list\": \"111:70,112:10\",\"township\":0,\"township_list\": \"\",\"rural\":20,\"rural_list\": \"220:20\"},\"airport_or_develop\": \"|机场|开发区\"}";

        var model = Newtonsoft.Json.JsonConvert.DeserializeObject<BaiduMapAPI.APIs.RecogAddress.V1.RecogResult>(json);
        Console.WriteLine("解析成功");
    }

    [Display(ShortName = "RegionSearch", Name = "行政区规划查询")]
    public static void TestRegionSearch(string AK, string SK)
    {
        do
        {
            Console.WriteLine("\r\n=====--------------=====\r\n");

            Console.Write("请输入关键字(按回车结束):");
            var keyword = Console.ReadLine();

            if (string.IsNullOrEmpty(keyword))
                keyword = "中国";

            Console.WriteLine($"即将搜索 -> [{keyword}]\r\n");

            BaiduMapAPI.APIs.RegionSearch.V1.Get get = new BaiduMapAPI.APIs.RegionSearch.V1.Get()
            {
                ExtensionsCode = true,
                Keyword = keyword,
                SubAdmin = BaiduMapAPI.APIs.RegionSearch.V1.SubAdmin.Level_2
            };

            var result = get.GetResult(AK, SK);

            Console.WriteLine($"  result.Status -> [{result.Status}]\r\n  result.Message -> [{result.Message}]\r\n  result.ResultSize -> [{result.ResultSize}]\r\n  result.DataVersion -> [{result.DataVersion}]");

            Console.WriteLine($"\r\n[代码]名称 <级别>");
            PrintDistrictResult(result.Districts);

            Console.Write("是否退出？[Y/N](按回车后确定):");
        } while (!(Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase));
    }

    private static void PrintDistrictResult(List<BaiduMapAPI.APIs.RegionSearch.V1.District> districts, int deep = 0)
    {
        if (districts != null)
        {
            // ┗ 
            var left = "";
            if (deep != 0)
            {
                left = "┗ ";
                left = left.PadLeft(deep + left.Length, ' ');
            }


            foreach (var item in districts)
            {
                Console.WriteLine($"{left}[{item.Code}]{item.Name} <{item.Level.GetDescription()}>");

                PrintDistrictResult(item.Districts, deep + 1);
            }
        }
    }

    [Display(ShortName = "traffic_road", Name = "道路实时路况查询")]
    public static void TestTrafficRoad(string AK, string SK)
    {
        Console.Write("请输入城市名称:");
        var city = Console.ReadLine();

        Console.Write("请输入路名:");
        var roadName = Console.ReadLine();

        BaiduMapAPI.APIs.Traffic.V1.Road road = new BaiduMapAPI.APIs.Traffic.V1.Road()
        {
            City = city,
            RoadName = roadName,

        };
        var result = road.GetResult(AK, SK);

        PrintTrafficResult(result);
    }

    [Display(ShortName = "traffic_bound", Name = "矩形区域实时路况查询")]
    public static void TestTrafficBound(string AK, string SK)
    {
        Console.Write("请输入左下角坐标信息(lng,lat):");
        var lcaL = Console.ReadLine();

        Console.Write("请输入右上角坐标信息(lng,lat):");
        var lcaR = Console.ReadLine();

        BaiduMapAPI.APIs.Traffic.V1.Bound road = new BaiduMapAPI.APIs.Traffic.V1.Bound()
        {
            RoadGrade = BaiduMapAPI.APIs.Traffic.V1.RoadGrade.All |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.BranchRoad |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.Expressway |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.HighSpeedRoad |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.SecondaryTrunkRoad |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.TrunkRoad,
            Bounds = new BaiduMapAPI.APIs.Traffic.V1.BoundInfo()
            {
                LeftBottom = new BaiduMapAPI.Models.Location(lcaL),
                RightTop = new BaiduMapAPI.Models.Location(lcaR)
            }
        };
        var result = road.GetResult(AK, SK);

        PrintTrafficResult(result);
    }

    [Display(ShortName = "traffic_around", Name = "周边实时路况查询")]
    public static void TestTrafficAround(string AK, string SK)
    {
        Console.Write("请输入坐标信息(lng,lat):");
        var lca = Console.ReadLine();

        int radius;

        do Console.Write("请输入查询半径(米)[1-1000]:");
        while (!int.TryParse(Console.ReadLine(), out radius));

        BaiduMapAPI.APIs.Traffic.V1.Around road = new BaiduMapAPI.APIs.Traffic.V1.Around()
        {
            RoadGrade = BaiduMapAPI.APIs.Traffic.V1.RoadGrade.All |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.BranchRoad |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.Expressway |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.HighSpeedRoad |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.SecondaryTrunkRoad |
             BaiduMapAPI.APIs.Traffic.V1.RoadGrade.TrunkRoad,
            Center = new BaiduMapAPI.Models.Location(lca),
            Radius = radius
        };
        var result = road.GetResult(AK, SK);

        PrintTrafficResult(result);
    }

    private static void PrintTrafficResult(BaiduMapAPI.APIs.Traffic.V1.RoadResult result)
    {
        Console.WriteLine($"  result.Status -> [{result.Status}]\r\n  result.Message -> [{result.Message}]\r\n  result.Description -> [{result.Description}]");

        if (result.Evaluation != null)
        {
            Console.WriteLine($"  路况总评：[{result.Evaluation.Status.GetDescription()}]{result.Evaluation.StatusDescription}");
        }

        if (result.RoadTraffic != null && result.RoadTraffic.Count > 0)
        {
            foreach (var item in result.RoadTraffic)
            {
                Console.WriteLine($"  道路名称：{item.RoadName}");
                if (item.CongestionSections != null && item.CongestionSections.Count > 0)
                {
                    foreach (var subItem in item.CongestionSections)
                    {
                        Console.WriteLine($"  [{subItem.Status.GetDescription()}]({subItem.Speed} km/h) {subItem.CongestionDistance}米 {subItem.CongestionTrend} {subItem.StatusDescription}");
                    }
                }
            }
        }

        Console.ReadLine();
    }

    [Display(ShortName = "timezone", Name = "测试时区")]
    public static void TestTimezone(string ak, string sk)
    {
        Console.Write("请输入坐标信息(lng,lat):");
        var lca = Console.ReadLine();
        var date = DateTime.Parse(DateTime.Now.ToUniversalTime().ToString("G"));
        BaiduMapAPI.APIs.TimeZone.V1.Get get = new BaiduMapAPI.APIs.TimeZone.V1.Get()
        {
            Timestamp = date,
            Location = new BaiduMapAPI.Models.Location(lca)
        };

        var result = get.GetResult(ak, sk);

        Console.WriteLine($"result.Status -> [{result.Status}] result.Message -> [{result.Message}]");
        Console.WriteLine($"result.TimeZoneID -> [{result.TimeZoneID}] result.DaylightSavingTimeOffset -> [{result.DaylightSavingTimeOffset}] result.RawOffset -> [{result.RawOffset}]");

        var newDate = date.AddSeconds(result.DaylightSavingTimeOffset ?? 0).AddSeconds(result.RawOffset ?? 0);

        Console.WriteLine($"data -> [{date}] newDate -> [{newDate}]");

        Console.ReadLine();
    }

    [Display(ShortName = "parking_search", Name = "推荐上车点服务")]
    public static void TestParkingSearch(string ak, string sk)
    {
        Console.Write("请输入坐标信息(lng,lat):");
        var lca = Console.ReadLine();

        //108.271151,22.856094
        BaiduMapAPI.APIs.Parking.Search search = new BaiduMapAPI.APIs.Parking.Search()
        {
            Location = new BaiduMapAPI.Models.Location(lca),
            CoordType = BaiduMapAPI.Models.Enums.CoordType.bd09ll,
        };

        var result = search.GetResult(ak, sk);

        Console.WriteLine($"result.Status -> [{result.Status}] result.Message -> [{result.Message}]");

        if (result.RecommendStops != null && result.RecommendStops.Count > 0)
        {
            foreach (var stop in result.RecommendStops)
            {
                Console.WriteLine($" {stop.Name} {stop.Distance}米 ({stop.Baidu})");
            }
        }

        Console.ReadLine();
    }

    [Display(ShortName = "si", Name = "静态地图")]
    public static void TestStaticimage(string ak, string sk)
    {


        //获取坐标
        Func<BaiduMapAPI.APIs.Staticimage.V2.Center> getCenter = () =>
        {
            BaiduMapAPI.Models.Location location = new BaiduMapAPI.Models.Location(Console.ReadLine());
            return new BaiduMapAPI.APIs.Staticimage.V2.Center(location.Lat ?? 0, location.Lng ?? 0);
        };

        //获取颜色
        Func<System.Drawing.Color> getColor = () =>
        {
            string pattern = "^\\#([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})$";
            string input;
            do
            {
                Console.Write("请输入颜色[格式如:#00FF00]:");
                input = Console.ReadLine() + "";
            } while (!System.Text.RegularExpressions.Regex.IsMatch(input, pattern));

            var values = System.Text.RegularExpressions.Regex.Replace(input, pattern, "$1|$2|$3").Split('|');

            int red = Convert.ToInt32(values[0], 16);
            int green = Convert.ToInt32(values[1], 16);
            int blue = Convert.ToInt32(values[2], 16);

            return System.Drawing.Color.FromArgb(red, green, blue);
        };

    Start:;

        BaiduMapAPI.APIs.Staticimage.V1.Get get = new BaiduMapAPI.APIs.Staticimage.V1.Get();

        Console.Write("请输入中心点坐标[lat,lng]:");
        get.Center = getCenter();

        get.Width = GetInputInt("请设置图片宽度(px):", 0, 512);

        get.Height = GetInputInt("请设置图片高度(px):", 0, 512);

        get.Zoom = GetInputInt("请设置地图级别(3 - 18):", 3, 18);

        Console.Write("是否添加标注[Y/N]:");

        if ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            get.Markers = new List<BaiduMapAPI.APIs.Staticimage.V2.Center>();
            get.MarkerStyles = new List<BaiduMapAPI.APIs.Staticimage.V2.MarkerStyle>();

            do
            {
                Console.Write("请输入标注坐标[lat,lng]:");
                get.Markers.Add(getCenter());

                var style = new BaiduMapAPI.APIs.Staticimage.V2.MarkerStyle();
                Console.Write("标注是否是图片?[Y/N]:");

                if ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.Write("请输入图片URL:");
                    style.URL = Console.ReadLine();
                }
                else
                {
                    Console.Write("请输入标注文本[0-9/A-Z]:");
                    style.Label = Console.ReadLine();

                    Console.WriteLine("请设置标注颜色:");
                    style.Color = getColor();

                    Console.WriteLine("请设置尺寸:");
                    style.Size = GetEnumValue<BaiduMapAPI.APIs.Staticimage.V2.MarkerStyleSize>();

                }

                get.MarkerStyles.Add(style);

                Console.Write("是否继续添加标注？[Y/N]:");
            } while ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase));
        }

        Console.Write("是否添加标签[Y/N]:");

        if ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            get.Labels = new List<BaiduMapAPI.APIs.Staticimage.V2.Center>();
            get.LabelStyles = new List<BaiduMapAPI.APIs.Staticimage.V2.LabelStyle>();


            do
            {
                Console.Write("请输入标签坐标[lat,lng]:");
                get.Labels.Add(getCenter());

                BaiduMapAPI.APIs.Staticimage.V2.LabelStyle style = new BaiduMapAPI.APIs.Staticimage.V2.LabelStyle()
                {
                    Border = true,
                    FontWeight = true,
                };

                Console.Write("请输入标签文本内容:");
                style.Content = Console.ReadLine() + "";

                style.FontSize = GetInputInt("请输入字体大小(0 - 96):", 0, 96);

                Console.WriteLine("请设置字体颜色:");
                style.FontColor = getColor();

                Console.WriteLine("请设置背景颜色:");
                style.BgColor = getColor();

                get.LabelStyles.Add(style);

                Console.Write("是否继续添加标签？[Y/N]:");
            } while ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase));
        }

        Console.Write("是否添加折线[Y/N]:");

        if ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            get.Paths = new List<BaiduMapAPI.APIs.Staticimage.V2.Center>();
            get.PathStyles = new List<BaiduMapAPI.APIs.Staticimage.V2.PathStyle>();

            do
            {
                Console.Write("请输入折线坐标[lat,lng]:");
                get.Paths.Add(getCenter());

                BaiduMapAPI.APIs.Staticimage.V2.PathStyle style = new BaiduMapAPI.APIs.Staticimage.V2.PathStyle();

                Console.WriteLine("请设置折线颜色:");
                style.Color = getColor();

                style.Weight = GetInputInt("请设置折线粗细(3 - 32):", 3, 32);

                style.Opacity = GetInputDouble("请设置折线或者面的透明度(0 - 1):", 0, 1);

                Console.Write("是否设置填充色?[Y/N]:");
                if ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("请设置填充色:");
                    style.FillColor = getColor();
                }

                get.PathStyles.Add(style);

                Console.Write("是否继续添加折线？[Y/N]:");
            } while ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase));
        }

        var result = get.GetResult(ak, sk);

        Console.WriteLine($"图片地址：\r\n{result.ImageURL}");

        using (var client = new HttpClient())
        {
            var response = client.GetAsync(result.ImageURL).Result;

            Console.WriteLine($"HttpStatus -> [{(int)response.StatusCode}]{response.StatusCode} {response.Content.Headers.ContentType}");

            var isImage = response.Content.Headers.ContentType?.MediaType?.Contains("image", StringComparison.CurrentCultureIgnoreCase);

            if (!isImage.GetValueOrDefault(false))
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                var fileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), $"{System.IO.Path.GetRandomFileName()}.png");

                System.IO.File.WriteAllBytes(fileName, response.Content.ReadAsByteArrayAsync().Result);

                Console.WriteLine($"图片路径：{fileName}");
            }
        }

        Console.Write("是否 Exist？[Y/N]:");
        if (!(Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase))
            goto Start;

        Console.WriteLine("按回车后结束程序");
        Console.ReadLine();
    }

    [Display(ShortName = "ConvertYingYanEntityList", Name = "测试转换鹰眼实体列表对象")]
    public static void TestConvertYingYanEntityList()
    {
        string json = "{\"status\": 0,\"message\": \"成功\",\"size\": 2,\"total\": 2,\"entities\": [{\"entity_name\": \"小王\",\"create_time\": \"2016-11-01 11:56:32\",\"modify_time\": \"2016-11-01 13:27:59\",\"latest_location\": {\"loc_time\": 1477978078,\"longitude\": 116.3189288575,\"latitude\": 40.04780579193,\"direction\": 64,\"height\": 53,\"radius\": 4,\"speed\": 37.73},\"city\": \"北京\",\"district\": \"海淀\",\"entity_desc\": \"小王_01\"},{\"entity_name\": \"小明\",\"create_time\": \"2017-03-15 15:56:04\",\"modify_time\": \"2017-06-01 14:01:31\",\"latest_location\": {\"loc_time\": 1488785466,\"longitude\": 116.45644006808,\"latitude\": 39.929082990815,\"direction\": 12,\"height\": 113.76,\"radius\": 3,\"speed\": 15.23},\"city\": \"北京\",\"district\": \"海淀\",\"entity_desc\": \"小明_01\"}]}";

        var model = Newtonsoft.Json.JsonConvert.DeserializeObject<BaiduMapAPI.YingYan.V3.Entity.ListResult>(json);

        Console.ReadLine();
    }

    [Display(ShortName = "addEntity", Name = "添加鹰眼实体")]
    public static void TestYingYanAddEntity(string ak)
    {
        BaiduMapAPI.YingYan.V3.Entity.Add add = new BaiduMapAPI.YingYan.V3.Entity.Add()
        {

        };

        add.ServiceID = GetInputInt("请输入服务ID:", 1, int.MaxValue);
        add.EntityName = GetInputString("请输入实体名称:");
        add.EntityDescription = GetInputString("请输入实体描述:");

        if (GetInputBool("是否输入自定义字段信息？", "Y", "N"))
        {
            add.CustomColumnValues = new Dictionary<string, string>();
            do
            {
                add.CustomColumnValues.Add(GetInputString("请输入 Column 名称:"), GetInputString("请输入值:"));
            } while (GetInputBool("是否继续添加自定字段？", "Y", "N"));
        }

        var addResult = add.GetResult(ak);

        Console.WriteLine($"Status -> [{addResult.Status}] Message -> [{addResult.Message}]");

        /*
         * 当前请求结果：Status -> [211] Message -> [APP SN校验失败]
         * 尚未向百度提工单询问。
         * 
         */

        Console.ReadLine();
    }

    [Display(ShortName = "updateEntity", Name = "添加鹰眼实体")]
    public static void TestYingYanUpdateEntity(string ak)
    {
        BaiduMapAPI.YingYan.V3.Entity.Update add = new BaiduMapAPI.YingYan.V3.Entity.Update()
        {

        };

        add.ServiceID = GetInputInt("请输入服务ID:", 1, int.MaxValue);
        add.EntityName = GetInputString("请输入实体名称:");
        add.EntityDescription = GetInputString("请输入实体描述:");

        if (GetInputBool("是否输入自定义字段信息？", "Y", "N"))
        {
            add.CustomColumnValues = new Dictionary<string, string>();
            do
            {
                add.CustomColumnValues.Add(GetInputString("请输入 Column 名称:"), GetInputString("请输入值:"));
            } while (GetInputBool("是否继续添加自定字段？", "Y", "N"));
        }

        var addResult = add.GetResult(ak);

        Console.WriteLine($"Status -> [{addResult.Status}] Message -> [{addResult.Message}]");
        /*
         * 当前请求结果：Status -> [211] Message -> [APP SN校验失败]
         * 尚未向百度提工单询问。
         * 
         */
        Console.ReadLine();
    }

    [Display(ShortName = "rectify", Name = "轨迹纠偏")]
    public static void TestRectify(string ak, string sk)
    {
        BaiduMapAPI.APIs.Track.V1.Rectify rectify = new BaiduMapAPI.APIs.Track.V1.Rectify();

        Console.WriteLine("请选择里程补偿设置:");
        rectify.SupplementMode = GetEnumValue<BaiduMapAPI.Models.Enums.SupplementMode>();
        rectify.RectifyOption = new BaiduMapAPI.APIs.Track.V1.RectifyOption();

        Console.WriteLine("请选择去噪力度:");
        rectify.RectifyOption.DenoiseGrade = GetEnumValue<BaiduMapAPI.Models.Enums.DenoiseGrade>();
        rectify.RectifyOption.NeedMapmatch = GetInputBool("是否需要将轨迹点绑路并补充道路形状点？", "Y", "N");

        Console.WriteLine("请选择交通方式:");
        rectify.RectifyOption.TransportMode = GetEnumValue<BaiduMapAPI.Models.Enums.TransportMode>();

        Console.WriteLine("请选择抽稀力度");
        rectify.RectifyOption.VacuateGrade = GetEnumValue<BaiduMapAPI.Models.Enums.VacuateGrade>();

        rectify.PointList = new List<BaiduMapAPI.APIs.Track.V1.RectifyPoint>();

        do
        {
            BaiduMapAPI.APIs.Track.V1.RectifyPoint point = new BaiduMapAPI.APIs.Track.V1.RectifyPoint();

            Console.WriteLine("请选择轨迹点的坐标系:");
            point.CoordTypeInput = GetEnumValue<BaiduMapAPI.Models.Enums.CoordType>() ?? BaiduMapAPI.Models.Enums.CoordType.bd09ll;


           

            point.Latitude = GetInputDouble("请输入轨迹点纬度:", double.MinValue, double.MaxValue);
            point.Longitude = GetInputDouble("请输入轨迹点经度:", double.MinValue, double.MaxValue);

            point.LocalTime = GetInputDateTime("请输入轨迹时间点:");

            if (GetInputBool("是否填写轨迹点的方向？", "Y", "N"))
                point.Direction = GetInputDouble("请输入轨迹点的方向[0-359]:", 0, 360);

            if (GetInputBool("是否填写轨迹点的高度？", "Y", "N"))
                point.Height = GetInputDouble("请输入轨迹点的高度:", 0, double.MaxValue);

            if (GetInputBool("是否填写定位精度？", "Y", "N"))
                point.Radius = GetInputInt("请输入精度(米):", 0, int.MaxValue);

            if (GetInputBool("是否填写时速？", "Y", "N"))
                point.Speed = GetInputDouble("请填写时速(km/h):", 0, double.MaxValue);

            rectify.PointList.Add(point);
        } while (GetInputBool("是否继续添加轨迹点？", "Y", "N"));


        var rectifyResult = rectify.GetResult(ak, sk);

        Console.WriteLine($"result.Status -> [{rectifyResult.Status}] result.Message -> [{rectifyResult.Message}]");

        Console.ReadLine();
    }

    private static DateTime GetInputDateTime(string text)
    {
        DateTime result;
        do Console.Write(text);
        while (!DateTime.TryParse(Console.ReadLine() + "", out result));
        return result;
    }

    /// <summary>
    /// 获取输入的 bool 值
    /// </summary>
    /// <param name="text"></param>
    /// <param name="yesValue"></param>
    /// <param name="noValue"></param>
    /// <returns></returns>
    private static bool GetInputBool(string text, string yesValue, string noValue)
    {
    Retry:
        Console.Write($"{text}[{yesValue}/{noValue}]:");

        var val = Console.ReadLine() + "";

        if (val.Equals(yesValue, StringComparison.InvariantCultureIgnoreCase)) return true;
        else if (val.Equals(noValue, StringComparison.InvariantCultureIgnoreCase)) return false;
        else goto Retry;
    }

    /// <summary>
    /// 获取输入的 string 值
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private static string GetInputString(string text)
    {
        Console.Write(text);
        return Console.ReadLine() + "";
    }

    /// <summary>
    /// 获取输入的 int 值
    /// </summary>
    /// <param name="text"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    private static int GetInputInt(string text, int min, int max)
    {
        int result;
        do Console.Write(text);
        while (!int.TryParse((Console.ReadLine() + ""), out result) || result < min || result > max);
        return result;
    }

    /// <summary>
    /// 获取输入的 double 值
    /// </summary>
    /// <param name="text"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    private static double GetInputDouble(string text, double min, double max)
    {
        double result;
        do Console.Write(text);
        while (!double.TryParse((Console.ReadLine() + ""), out result) || result < min || result > max);
        return result;
    }

    private static TEnum? GetEnumValue<TEnum>()
        where TEnum : struct
    {
        TEnum? result = null;// default(TEnum?);
        var enumType = typeof(TEnum);
        var fields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);

        TEnum input;
        do
        {

            Console.WriteLine("可选范围:");
            foreach (var field in fields)
            {
                var item = Enum.Parse(enumType, field.Name);
                var description = field.GetCustomAttribute<DescriptionAttribute>(true);
                Console.WriteLine($"    [{(int)item}|{item}] {description?.Description}");
            }
            Console.Write("请输入上列选项中方框内的数字或单词:");
        } while (!Enum.TryParse((Console.ReadLine() + ""), out input));

        result = input;

        return result;
    }


}