

using AutoMapper;
using FrameWork.Common;
using FrameWork.Entity.Model.Classmate;

namespace FrameWork.Entity.ViewModel.Classmate
{
    public class GetMyClassmateDeatilViewModel
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
        /// 正在学习的大类
        /// </summary>
        public string NowCategory { set; get; }

        /// <summary>
        /// 是否已经
        /// </summary>
        public bool IsAdd { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { set; get; }

        /// <summary>
        /// 距离
        /// </summary>
        public string Distance { set; get; }

        /// <summary>
        /// 获取返回给前台的数据模型
        /// </summary>
        public GetMyClassmateDeatilViewModel GetViewModel(GetMyClassmateDeatilModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GetMyClassmateDeatilModel, GetMyClassmateDeatilViewModel>()
                .ForMember(d => d.UserHeadImg, opt => opt.NullSubstitute("https://file.nbig.com.cn/default/defaultStudent.png"))
                .ForMember(d => d.UserName, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.NowCategory, opt => opt.NullSubstitute(string.Empty)));
            var mapper = config.CreateMapper();
            var viewModel = mapper.Map<GetMyClassmateDeatilViewModel>(model);
            if (model.Distance < 1)
            {
                viewModel.Distance = $@"{(int)(model.Distance * 1000)}m";
            }
            else
            {
                viewModel.Distance = $@"{model.Distance:F1}km";
            }

            return viewModel;
        }

    }

    /// <summary>
    /// 请求参数
    /// </summary>
    public class GetMyClassmateDeatilRequest
    {
        public int UserId { set; get; }
    }
}
