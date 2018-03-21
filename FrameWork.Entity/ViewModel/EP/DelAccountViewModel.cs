/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                DelAccountViewModel.cs
 *      Description:
 *            DelAccountViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/21 20:36:41
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// DelAccountRequest
    /// </summary>
    public class DelAccountRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }
       
        /// <summary>
        /// 子账号id
        /// </summary>
        public int SubAccoundId { set; get; }
    }
}
