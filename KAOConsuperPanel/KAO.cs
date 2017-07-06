using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.KAOConsuperPanel
{
    class KAO
    {
        public static string[] citys =
        {
                "上海",
                "苏州",
                "广州",
                "深圳",
                "南京",
                "杭州"
            };
        public static Dictionary<string, string> cityTable = new Dictionary<string, string>
        {
            {"shenzhen", "深圳" },
            {"nanjing", "南京" },
            {"suzhou", "苏州" },
            {"hangzhou", "杭州" },
            {"guangzhou", "广州" },
            {"shanghai", "上海" }
        };
    }
}
