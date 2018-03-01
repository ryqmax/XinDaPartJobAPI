

using System;
using System.Collections.Generic;
using System.Linq;
using FrameWork.Common;
using FrameWork.Entity.Model.Classmate;

namespace FrameWork.Entity.ViewModel.Classmate
{
    public class GetMyClassmateListRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 页码数
        /// </summary>
        public int Page { set; get; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { set; get; }
    }

    /// <summary>
    /// 给我加能量的模型
    /// </summary>
    public class GetMyClassmateListViewModel
    {
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool IsHaveNext { set; get; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { set; get; }

        /// <summary>
        /// 用户列表
        /// </summary>
        public List<UserItem> UserList = new List<UserItem>();

        /// <summary>
        /// 获取数据模型
        /// </summary>
        public GetMyClassmateListViewModel GetViewModel(List<GetMyClassmateListModel> models, GetMyClassmateListRequest req)
        {
            var viewModel = new GetMyClassmateListViewModel();
            if (models.Any())
            {
                var item = models.First();
                viewModel.IsHaveNext = PageHelper.JudgeNextPage(item.TotalCount, req.Page, req.PageSize);
                viewModel.TotalCount = item.TotalCount;
                foreach (var model in models)
                {
                    viewModel.UserList.Add(new UserItem
                    {
                        CreateTime = GetTime(model.CreateTime),
                        EnergyCount = model.EnergyCount,
                        IsAdd = model.IsAdd,
                        NowCategory = model.NowCategory ?? "",
                        UserId = model.UserId,
                        UserName = model.UserName ?? "",
                        UserHeadImg = PictureHelper.GetStudentImg(model.UserHeadImg)
                    });
                }
            }

            return viewModel;
        }

        /// <summary>
        /// 根据添加能量的时间转换成对应的字符串
        /// </summary>
        public string GetTime(DateTime createTime)
        {
            var str = string.Empty;
            createTime = new DateTime(createTime.Year, createTime.Month, createTime.Day, 0, 0, 0);
            var nowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var sub = (nowTime - createTime).Days;
            if (sub == 0)
            {
                str = "今天";
            }
            else if (sub == 1)
            {
                str = "昨天";
            }
            else if (sub == 2)
            {
                str = "前天";
            }
            else
            {
                str = createTime.ToString("yyyy-MM-dd");
            }
            return str;
        }

    }

    /// <summary>
    /// 用户列表模型
    /// </summary>
    public class UserItem
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 能量值
        /// </summary>
        public int EnergyCount { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserHeadImg { set; get; }

        /// <summary>
        /// 添加能量的时间
        /// </summary>
        public string CreateTime { set; get; }

        /// <summary>
        /// 正在学习的大类
        /// </summary>
        public string NowCategory { set; get; }

        /// <summary>
        /// 是否已经
        /// </summary>
        public bool IsAdd { set; get; }

    }
}
