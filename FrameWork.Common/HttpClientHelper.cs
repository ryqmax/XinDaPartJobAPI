using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FrameWork.Common
{
    public static class HttpClientHelper
    {    /// <summary>  
         /// 获取url的返回值  
         /// </summary>  
         /// <param name="url">eg:http://m.weather.com.cn/atad/101010100.html </param>  
        public static int GetInfo(string url)
        {
            try
            {
                Uri httpURL = new Uri(url);
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
                HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
                Stream respStream = httpResp.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                var strBuff = respStreamReader.ReadToEnd().ObjToInt();
            }
            catch (Exception e)
            {
                return e.HResult;
            }
            return 200;
        }
        public static HttpClient Create(string baseUrl)
        {
            return Create(MimeFormat.JSON, baseUrl);
        }

        public static HttpClient Create(MimeFormat format, string baseUrl)
        {
            HttpClient client = new HttpClient();
            switch (format)
            {
                case MimeFormat.XML:
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/xml"));
                    break;
                case MimeFormat.JSON:
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    break;
                case MimeFormat.File:
                    client.DefaultRequestHeaders.Accept.Add(
                      new MediaTypeWithQualityHeaderValue(" multipart/form-data"));
                    break;
            }

            if (baseUrl != string.Empty)
                client.BaseAddress = new Uri(baseUrl);

            return client;
        }

        public static string GetString(this HttpClient client)
        {
            var responseMessage = client.GetAsync("").Result;
            var result = responseMessage.Content.ReadAsStringAsync().Result;
            return result;
        }
        public static string doPost(this HttpClient client,
            string jsonValue)
        {
            StringContent content = new System.Net.Http.StringContent(jsonValue, Encoding.UTF8, "application/json");
            var responseMessage = client.PostAsync("", content).Result;
            var result = responseMessage.Content.ReadAsStringAsync().Result;
            return result;
        }
        public static string doUpload(this HttpClient client)
        {


            FileStream fs = new FileStream(@"C:\btn.png", FileMode.Open);
            //把文件读取到字节数组
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            //实例化一个内存流--->把从文件流中读取的内容[字节数组]放到内存流中去
            MemoryStream ms = new MemoryStream(data);
            // StreamContent content = new System.Net.Http.StreamContent(ms,data.Length);


            HttpContent content = new StreamContent(ms);
            MultipartFormDataContent formDataContent = new MultipartFormDataContent();
            formDataContent.Add(content, "btn");



            var responseMessage = client.PostAsync("", formDataContent).Result;
            var result = responseMessage.Content.ReadAsStringAsync().Result;
            return result;
        }

        /// <summary>
        /// 发起一个HTTP请求（以POST方式）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string HttpPost(string url, string param = "")
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "*/*";
            request.Timeout = 10000;
            request.AllowAutoRedirect = false;
            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;
            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());
                requestStream.Write(param);
                requestStream.Close();
                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }
            return responseStr;
        }

        /// <summary>
        /// get请求
        /// </summary>
        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static void SendMessage(string url, string jsonString)
        {
            HttpClient client = new HttpClient();
            HttpContent httpContext = new StringContent(jsonString, Encoding.UTF8);
            httpContext.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //await异步等待回应
            client.PostAsync(url, httpContext).ContinueWith(t =>
            {
                // Get HTTP response from completed task. 
                HttpResponseMessage response = t.Result;
                // Check that response was successful or throw exception 
                response.EnsureSuccessStatusCode();
                // Read response asynchronously as JsonValue and write out top facts for each country 
                response.Content.ReadAsStringAsync().ContinueWith(
                    (readTask) =>
                    {                        
                        Console.WriteLine(readTask.Result + " time:==>" + DateTime.Now);

                    });
            });
        }

        /// <summary>
        /// 只是发送get请求,带有返回值
        /// </summary>
        public static string SendMessage(string url, Encoding encode = null)
        {
            string result;
            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };
                if (encode != null)
                    webClient.Encoding = encode;
                result = webClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

    }
    public static class HttpClientType
    {
        public static readonly string CRUD = "CRUD";
        public static readonly string CRUD_CREATE = "C";
        public static readonly string CRUD_UPDATE = "U";
        public static readonly string CRUD_RETRIVE = "R";
        public static readonly string CRUD_DELETE = "D";
    }

    /// <summary>
    /// Mime内容格式
    /// </summary>
    public enum MimeFormat
    {
        XML = 0,
        JSON = 1,
        File = 3
    }
}
