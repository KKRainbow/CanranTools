using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Tools
    {
        private static Dictionary<string, string> provinceDict = new Dictionary<string, string>
            {
                {"全国", "TotalChina"},
                {"安徽","anhuisheng"},
                {"澳门特别行政区","nTebieXingzhengqu"},
                {"北京","Beijingshi"},
                {"重庆","Chongqingshi"},
                {"福建","Fujiansheng"},
                {"甘肃","Gansusheng"},
                {"广东","Guangdongsheng"},
                {"广西壮族自治区","GuangxiZhuangzuzizhiqu"},
                {"贵州","Guizhousheng"},
                {"海南","Hainansheng"},
                {"河北","Hebeisheng"},
                {"黑龙江","Heilongjiangsheng"},
                {"河南","Henansheng"},
                {"湖北","Hubeisheng"},
                {"湖南","Hunansheng"},
                {"江苏","Jiangsusheng"},
                {"江西","Jiangxisheng"},
                {"吉林","Jilinsheng"},
                {"辽宁","Liaoningsheng"},
                {"内蒙古","Neimengguzizhiqu"},
                {"宁夏回族自治区","NingxiaHuizuzizhiqu"},
                {"青海","Qinghaisheng"},
                {"陕西","Shaanxisheng"},
                {"山东","Shandongsheng"},
                {"上海","Shanghaishi"},
                {"山西","Shanxisheng"},
                {"四川","Sichuansheng"},
                {"台湾","Taiwansheng"},
                {"天津","Tianjinshi"},
                {"香港特别行政区","XianggangTebieXingzhengqu"},
                {"新疆维吾尔族自治区","XinjiangWeiwuerzuzizhiqu"},
                {"西藏自治区","Xizangzizhiqu"},
                {"云南","Yunnansheng"},
                {"浙江","Zhejiangsheng"},
            };
        public static string ProvincePinyinToHanzi(string pinyin)
        {
            foreach (var k in provinceDict)
            {
                if (k.Value.ToLower().Contains(pinyin.ToLower()))
                {
                    return k.Key;
                }
            }
            return pinyin;
        }
        public static string ProvinceHanziToPinyin(string hanzi)
        {
            foreach (var k in provinceDict)
            {
                if (k.Key.Contains(hanzi))
                {
                    return k.Value;
                }
            }
            return hanzi;
        }
    }
}
