/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                UserShowModel.cs
 *      Description:
 *            UserShowModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 16:09:45
 *      History:
 ***********************************************************************************/

using System.Collections.Generic;

namespace FrameWork.Entity.ViewModel.Course
{
    /// <summary>
    /// FreeVideoViewModel
    /// </summary>
    public class FreeVideoListViewModel
    {
        public List<FreeVideoViewModel> VideoList = new List<FreeVideoViewModel>();
        public bool IsEnd { get; set; }
    }
}
