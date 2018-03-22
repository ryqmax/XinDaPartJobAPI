/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                DelEPAddressViewModel.cs
 *      Description:
 *            DelEPAddressViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 14:26:02
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.EPAddress
{
    /// <summary>
    /// DelEPAddressRequest
    /// </summary>
    public class DelEPAddressRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 地址id
        /// </summary>
        public int AddressId { get; set; }

    }
}
