using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace FrameWork.Common
{
    public class IpHelp
    {
        /// <summary>
        /// 获取客户端Ip
        /// 
        /// </summary>
        /// <returns></returns>
        public static String GetClientIp()
        {
            var clientIp = "127.0.0.1";
            if (System.Web.HttpContext.Current != null)
            {
                clientIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(clientIp) || (clientIp.ToLower() == "unknown"))
                {
                    clientIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_REAL_IP"];
                    if (string.IsNullOrEmpty(clientIp))
                    {
                        clientIp = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    try
                    {
                        clientIp = clientIp.Split(',')[0];
                    }
                    catch (Exception)
                    {

                    }

                }
            }

            if (!String.IsNullOrEmpty(clientIp) && "::1".Equals(clientIp))
            {
                clientIp = "127.0.0.1";
            }
            return clientIp;
        }

        /// <summary>
        /// 获取发起微信支付的服务器IP
        /// </summary>
        public static string GetServerIp()
        {
            try
            {
                var hostName = Dns.GetHostName(); //得到主机名
                var ipEntry = Dns.GetHostEntry(hostName);
                for (var i = 0; i < ipEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (ipEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ipEntry.AddressList[i].ToString();
                    }
                }
                return "39.104.73.103";
            }
            catch (Exception ex)
            {
                return "39.104.73.103";
            }
        }
    }
}