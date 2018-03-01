using System;
using System.IO;
using System.Net;
using System.Text;
using FrameWork.Common.Models;
using Newtonsoft.Json.Linq;

namespace FrameWork.Common.ThirdTools
{
    /// <summary>
    /// 环信服务器端会员访问接口Demo
    /// Author：Mr.Hu
    /// QQ:346163801
    /// Email:346163801@qq.com
    /// 如有任何问题，可QQ或邮箱联系
    /// </summary>
    public class EaseMobDemo
    {
        string reqUrlFormat = "https://a1.easemob.com/{0}/{1}/";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AppName { get; set; }
        public string OrgName { get; set; }
        public string token { get; set; }
        public string EaseMobUrl { get { return string.Format(reqUrlFormat, OrgName, AppName); } }

        /// <summary>
        /// 构造函数
        /// </summary>
        public EaseMobDemo()
        {
            this.ClientId = "YXA6YYt3ACu-Eee3iU-Cdn1Ucw";
            this.ClientSecret = "YXA6YnpSKI6weLIvU0Ulw7EJtHqAhRI";
            this.AppName = "huikaoba";
            this.OrgName = "1157170312178835";
            this.token = QueryToken();
        }

        /// <summary>
        /// 使用app的client_id 和 client_secret登陆并获取授权token
        /// </summary>
        /// <returns></returns>
        string QueryToken()
        {
            if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(ClientSecret)) { return string.Empty; }
            string cacheKey = ClientId + ClientSecret;
            if (System.Web.HttpRuntime.Cache.Get(cacheKey) != null &&
                System.Web.HttpRuntime.Cache.Get(cacheKey).ToString().Length > 0)
            {
                return System.Web.HttpRuntime.Cache.Get(cacheKey).ToString();
            }

            string postUrl = EaseMobUrl + "token";
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"grant_type\": \"client_credentials\",\"client_id\": \"{0}\",\"client_secret\": \"{1}\"", ClientId, ClientSecret);
            _build.Append("}");

            string postResultStr = ReqUrl(postUrl, "POST", _build.ToString(), string.Empty);
            string token = string.Empty;
            int expireSeconds = 0;
            try
            {
                JObject jo = JObject.Parse(postResultStr);
                token = jo.GetValue("access_token").ToString();
                int.TryParse(jo.GetValue("expires_in").ToString(), out expireSeconds);
                //设置缓存
                if (!string.IsNullOrEmpty(token) && token.Length > 0 && expireSeconds > 0)
                {
                    System.Web.HttpRuntime.Cache.Insert(cacheKey, token, null, DateTime.Now.AddSeconds(expireSeconds), System.TimeSpan.Zero);
                }
            }
            catch { return postResultStr; }
            return token;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountCreate(string userName, string password)
        {
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"username\": \"{0}\",\"password\": \"{1}\"", userName, password);
            _build.Append("}");

            return AccountCreate(_build.ToString());
        }
       
        /// <summary>
        /// 创建群组
        /// </summary>
        /// <returns>创建成功的群组JSON</returns>
        public string CreateGroup(string groupname, string desc,int maxusers, string owner)
        {
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"groupname\": \"{0}\",\"desc\": \"{1}\",\"maxusers\": {2},\"owner\": \"{3}\",\"members\": [\"{3}\"],\"public\": true,\"approval\": false", groupname, desc, maxusers, owner);
            _build.Append("}");
            return CreateGroup(_build.ToString());
        }

        /// <summary>
        /// 修改群组
        /// </summary>
        /// <returns>修改成功的群组JSON</returns>
        public string UpdateGroup(string groupId, string name, string description, int maxusers)
        {
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"groupname\": \"{0}\",\"description\": \"{1}\",\"maxusers\": {2}", name, description, maxusers);
            _build.Append("}");
            return UpdateGroup(groupId, _build.ToString());
        }

        /// <summary>
        /// 创建群组
        /// </summary>
        /// <returns>创建成功的群组JSON</returns>
        private string CreateGroup(string postData) { return ReqUrl(EaseMobUrl + "chatgroups", "POST", postData, token); }

        /// <summary>
        /// 删除群组
        /// </summary>
        /// <param name="groupId">群组ID</param>
        /// <returns>删除成功的群组JSON</returns>
        public string DeleteGroupById(string groupId) { return ReqUrl(EaseMobUrl + "chatgroups/" + groupId, "DELETE", string.Empty, token); }

        /// <summary>
        /// 修改群组
        /// </summary>
        /// <returns>修改成功的群组JSON</returns>
        private string UpdateGroup(string groupId, string postData) { return ReqUrl(EaseMobUrl + "chatgroups/" + groupId, "PUT", postData, token); }

        /// <summary>
        /// 获取群组详情
        /// </summary>
        /// <param name="groupId">群组ID</param>
        /// <returns>获取成功的群组JSON</returns>
        public string GetGroupById(string groupId) { return ReqUrl(EaseMobUrl + "chatgroups/" + groupId, "GET", string.Empty, token); }

        /// <summary>
        /// 群组加人
        /// </summary>
        /// <param name="groupId">群组ID</param>
        /// <param name="username">用户名</param>
        /// <returns>返回成功的群组JSON</returns>
        public string AddMemberByGroupId(string groupId,string username) { return ReqUrl(EaseMobUrl + "chatgroups/" + groupId+ "/users/"+username, "POST", string.Empty, token); }

        /// <summary>
        /// 群组减人
        /// </summary>
        /// <param name="groupId">群组ID</param>
        /// <param name="username">用户名</param>
        /// <returns>返回成功的群组JSON</returns>
        public string DeleteMemberByGroupId(string groupId, string username) { return ReqUrl(EaseMobUrl + "chatgroups/" + groupId + "/users/" + username, "DELETE", string.Empty, token); }

        /// <summary>
        /// 获取用户参与的群组
        /// </summary>
        /// <param name="username">群组ID</param>
        /// <returns>获取成功的群组JSON</returns>
        public string GetGroupByUserName(string username) { return ReqUrl(EaseMobUrl + "users/" + username+ "/joined_chatgroups", "GET", string.Empty, token); }

        /// <summary>
        /// 直接创建聊天室并返回聊天室ID
        /// </summary>
        /// <returns>聊天室ID</returns>
        public string CreateChatRoom()
        {
            var str = CreateChatRoom("ChatRoom", "ChatRoomdesc", 5000, "5b-92-ed-d2-f7-cc-35-d0-1c-fe-36-2e-d2-1a-f0-55");
            var model = JObject.Parse(str).GetValue("data").ToObject<ChatRoomModel>();
            return model.Id;
        }

        /// <summary>
        /// 创建聊天室
        /// </summary>
        /// <returns>创建成功的聊天室JSON</returns>
        public string CreateChatRoom(string name, string desc, int maxusers, string owner)
        {
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"name\": \"{0}\",\"description\": \"{1}\",\"maxusers\": {2},\"owner\": \"{3}\"", name, desc, maxusers, owner);
            _build.Append("}");
            return CreateChatRoom(_build.ToString());
        }

        /// <summary>
        /// 创建聊天室
        /// </summary>
        /// <returns>创建成功的聊天室JSON</returns>
        private string CreateChatRoom(string postData) { return ReqUrl(EaseMobUrl + "chatrooms", "POST", postData, token); }


        /// <summary>
        /// 修改聊天室
        /// </summary>
        /// <returns>修改成功的聊天室JSON</returns>
        public string UpdateRoom(string roomId, string name, string description, int maxusers)
        {
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"name\": \"{0}\",\"description\": \"{1}\",\"maxusers\": {2}", name, description, maxusers);
            _build.Append("}");
            return UpdateRoom(roomId,_build.ToString());
        }
        
        /// <summary>
        /// 获取群组列表
        /// </summary>
        /// <returns>获取成功的群组JSON</returns>
        public string GetGroupList() { return ReqUrl(EaseMobUrl + "chatgroups", "GET",string.Empty, token); }

        /// <summary>
        /// 修改聊天室
        /// </summary>
        /// <returns>修改成功的聊天室JSON</returns>
        private string UpdateRoom(string roomId,string postData) { return ReqUrl(EaseMobUrl + "chatrooms/"+roomId, "PUT", postData, token); }
        
        /// <summary>
        /// 获取聊天室详情
        /// </summary>
        /// <param name="roomId">聊天室ID</param>
        /// <returns>获取成功的聊天室JSON</returns>
        public string GetRoomById(string roomId) { return ReqUrl(EaseMobUrl + "chatrooms/"+ roomId, "GET", string.Empty, token); }

        /// <summary>
        /// 删除聊天室
        /// </summary>
        /// <param name="roomId">聊天室ID</param>
        /// <returns>删除成功的聊天室JSON</returns>
        public string DeleteRoomById(string roomId) { return ReqUrl(EaseMobUrl + "chatrooms/" + roomId, "DELETE", string.Empty, token); }

        /// <summary>
        ///获取聊天室记录
        /// </summary>
        public string GetChatMessages() { return ReqUrl(EaseMobUrl + "chatmessages?limit=500", "GET", string.Empty, token); }

        /// <summary>
        /// 创建用户(可以批量创建)
        /// </summary>
        /// <param name="postData">创建账号JSON数组--可以一个，也可以多个</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountCreate(string postData) { return ReqUrl(EaseMobUrl + "users", "POST", postData, token); }

        /// <summary>
        /// 获取指定用户详情
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>会员JSON</returns>
        public string AccountGet(string userName) { return ReqUrl(EaseMobUrl + "users/" + userName, "GET", string.Empty, token); }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>重置结果JSON(如：{ "action" : "set user password",  "timestamp" : 1404802674401,  "duration" : 90})</returns>
        public string AccountResetPwd(string userName, string newPassword) { return ReqUrl(EaseMobUrl + "users/" + userName + "/password", "PUT", "{\"newpassword\" : \"" + newPassword + "\"}", token); }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountDel(string userName) { return ReqUrl(EaseMobUrl + "users/" + userName, "DELETE", string.Empty, token); }

        public string ReqUrl(string reqUrl, string method, string paramData, string token)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(reqUrl) as HttpWebRequest;
                request.Method = method.ToUpperInvariant();

                if (!string.IsNullOrEmpty(token) && token.Length > 1) { request.Headers.Add("Authorization", "Bearer " + token); }
                if (request.Method.ToString() != "GET" && !string.IsNullOrEmpty(paramData) && paramData.Length > 0)
                {
                    request.ContentType = "application/json";
                    byte[] buffer = Encoding.UTF8.GetBytes(paramData);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }
                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    //System.Threading.Thread.Sleep(1000);
                    using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        string result = stream.ReadToEnd();
                        return result;
                    }
                }
            }
            catch (Exception ex) { return ex.ToString(); }
        }
    }
}
