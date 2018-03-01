using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FrameWork.Common.ThirdTools
{
    /// <summary>
    /// 环信服务器端会员访问接口Demo
    /// Author：Mr.Hu
    /// QQ:346163801
    /// Email:346163801@qq.com
    /// 如有任何问题，可QQ或邮箱联系
    /// </summary>
    public class VideoLiveTencentHelp
    {
        private string ReqUrlFormat = "https://live.api.qcloud.com/v2/index.php";
        private string ReqUrlForVideo = "https://vod.api.qcloud.com/v2/index.php";
        
        public  string SecretId { get; set; }
        public  string SecretKey { set; get; }
        public  string Region { set; get; }//区域
        public  long Timestamp { set; get; }//当前时间戳
        public  int Nonce { set; get; }//随机正整数:
        public  string Signature { set; get; }//签名
        public  string EnSignature { set; get; }

        //参数按字母升序排序

        /// <summary>
        /// 构造函数
        /// </summary>
        public VideoLiveTencentHelp()
        {
             SecretId = "AKIDSw6gsazqFcJRHcCHIe3sVSV3qYjJ6i1Z";
             SecretKey = "PCcg2K2z4DbUPW5BTJBdWyWJ8JloahJR";
             Region = "qd";
             Nonce = new Random().Next(100, 99999999);//随机正整数
             //EnSignature = "GETlive.api.qcloud.com/v2/index.php?Action={0}&Nonce=" + Nonce + "&Region=" + Region + "&SecretId=" + SecretId + "&Timestamp={1}";
        }

        /// <summary>
        /// 生成签名 
        /// 要穿的参数都要加密
        /// </summary>
        /// <param name="action">方法名字</param>
        /// <returns></returns>
        public string QuerySignature(string str)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(SecretKey));
            byte[] rstRes = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(str));
            string strs =  Convert.ToBase64String(rstRes);
            return System.Web.HttpUtility.UrlEncode(strs);
        }
        
        /// <summary>
        /// 获取录制的视频
        /// </summary>
        /// <param name="fileName">文件名</param>
        public string GetVideo(string fileName)
        {
            //签名原文的拼接规则为:
            //请求方法 + 请求主机 + 请求路径 + ? +请求字符串
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Timestamp = Convert.ToInt64(ts.TotalSeconds);//获取时间戳
            string str = string.Format("GETvod.api.qcloud.com/v2/index.php?Action=DescribeVodPlayInfo"+ "&Nonce=" + Nonce + "&SecretId=" + SecretId + "&Timestamp="+Timestamp + "&fileName=" + fileName);
            Signature = QuerySignature(str);
            var fileNameEncode = HttpUtility.UrlPathEncode(fileName);
            string para = "Action=DescribeVodPlayInfo" + "&fileName=" + fileNameEncode + "&Nonce=" + Nonce + "&Signature=" + Signature + "&SecretId=" + SecretId + "&Timestamp=" + Timestamp;
            return ReqUrlForVideo + "?" + para;
        }

        /// <summary>
        /// 开始转码
        /// </summary>
        /// <param name="fileId">文件id</param>
        public string Transcoding(string fileId)
        {
            int isScreenshot = 1;
            int isWatermark = 1;
            //签名原文的拼接规则为:
            //请求方法 + 请求主机 + 请求路径 + ? +请求字符串
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Timestamp = Convert.ToInt64(ts.TotalSeconds);//获取时间戳
            string str = string.Format("GETvod.api.qcloud.com/v2/index.php?Action=ConvertVodFile" + "&Nonce=" + Nonce + "&SecretId=" + SecretId + "&Timestamp=" + Timestamp + "&fileId=" + fileId + "&isScreenshot=" + isScreenshot + "&isWatermark=" + isWatermark);
            Signature = QuerySignature(str);
            string para = "Action=ConvertVodFile" + "&fileId=" + fileId + "&isScreenshot=" + isScreenshot + "&isWatermark=" + isWatermark + "&Nonce=" + Nonce + "&Signature=" + Signature + "&SecretId=" + SecretId + "&Timestamp=" + Timestamp;
            return ReqUrlForVideo + "?" + para;
        }

        public string ReqUrl(string reqUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(reqUrl) as HttpWebRequest;
                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    System.Threading.Thread.Sleep(2000);
                    using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        System.Threading.Thread.Sleep(1000);
                        string result = stream.ReadToEnd();
                        System.Threading.Thread.Sleep(1000);
                        return result;
                    }
                }
            }
            catch (Exception ex) { return ex.ToString(); }
        }
    }
}
