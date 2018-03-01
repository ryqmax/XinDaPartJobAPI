
using System.Collections.Generic;
using System.Linq;
using FrameWork.Common;
using FrameWork.Entity.Model.Classmate;

namespace FrameWork.Entity.ViewModel.Classmate
{
    public class GetMyClassmateMapDataRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 行业id
        /// </summary>
        public int IndustryId { set; get; }
    }

    public class GetMyClassmateMapDataViewModel
    {
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { set; get; }

        /// <summary>
        /// 用户列表
        /// </summary>
        public List<UserPositionItem> UserList = new List<UserPositionItem>();

        /// <summary>
        /// 获取视图模型
        /// </summary>
        public GetMyClassmateMapDataViewModel GetViewModel(List<GetMyClassmateMapDataModel> models, GetMyClassmateMapDataRequest req)
        {
            var viewModel = new GetMyClassmateMapDataViewModel();
            if (models.Any())
            {
                var item = models.FirstOrDefault(u => u.UserId == req.UserId);
                if (item != null)
                {
                    viewModel.Longitude = item.Longitude;
                    viewModel.Latitude = item.Latitude;
                }
                foreach (var model in models)
                {
                    if (model.UserId != req.UserId)
                        viewModel.UserList.Add(new UserPositionItem
                        {
                            id = model.UserId,
                            longitude = model.Longitude,
                            latitude = model.Latitude
                        });
                }
            }

            return viewModel;
        }
    }

    /// <summary>
    /// 用户位置模型
    /// </summary>
    public class UserPositionItem
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int id { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        public double longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double latitude { set; get; }

        /// <summary>
        /// 地图图标
        /// </summary>
        public string iconPath { set; get; } = "/image/classmate/map-marker.png";

        /// <summary>
        /// 宽度
        /// </summary>
        public int width { set; get; } = 40;

        /// <summary>
        /// 高度
        /// </summary>
        public int height { set; get; } = 50;
    }
}
