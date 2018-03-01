using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel
{
    public class BaseViewModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Msg { set; get; }

        /// <summary>
        /// 返回消息内容
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// 返回结果码
        /// 成功：10000，失败：20000
        /// </summary>
        public int ResultCode { set; get; }

        /// <summary>
        /// 接口返回结果
        /// </summary>
        public object Info { set; get; }

    }
}
