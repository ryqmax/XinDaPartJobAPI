using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Account;
using FrameWork.Entity.Model.Classmate;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Classmate;

namespace FrameWork.Interface
{
    public interface IAccountService : IBaseService<T_User>
    {
        /// <summary>
        /// 登录
        /// </summary>
        T_User Login(LoginViewModel loginViewModel);

        /// <summary>
        /// 获取该微信的用户信息
        /// </summary>
        /// <param name="openId">微信账号</param>
        /// <param name="request">用户参数</param>
        T_Student GetStudent(string openId, GetUserInfoRequest request);

        /// <summary>
        /// 提交用户信息
        /// </summary>
        int SubmitUserInfo(SubmitUserInfoRequest request);

        /// <summary>
        /// 获取学员用户的课程列表
        /// </summary>
        List<GetMyCourseListModel> GetMyCourseList(GetMyCourseListRequest request);

        /// <summary>
        /// 生成订单并获取小节的信息
        /// </summary>
        T_SectionVideo GetWeChatPayParameter(GetWeChatPayParameterRequest request, string number);

        /// <summary>
        /// 更新订单状态，把小节和用户关联起来
        /// </summary>
        /// <param name="number">订单编号</param>
        int UpdateOrderStatus(string number);

        /// <summary>
        /// 获取用户的能量值
        /// </summary>
        UserEnergy GetUserEnergy(GetClassmateNumRequest req);

        /// <summary>
        /// 获取给这个用户添加能量的用户列表
        /// </summary>
        List<UserInfoModel> GetInfoModels(GetClassmateNumRequest req);

        /// <summary>
        /// 获取行业及行业下的用户数量
        /// </summary>
        List<IndustryUserCountModel> GetIndustryUserCountModels(GetClassmateNumRequest req);

        /// <summary>
        /// 获取某个行业下的所有学生列表
        /// </summary>
        List<GetClassmateInfoModel> GetClassmateInfoModels(GetClassmateInfoRequest req);

        /// <summary>
        /// 给同学加能量
        /// </summary>
        int AddEnergyValue(AddEnergyValueRequest req);

        /// <summary>
        /// 获取给我加能量的同学
        /// </summary>
        List<GetMyClassmateListModel> GetMyClassmateList(GetMyClassmateListRequest req);

        /// <summary>
        /// 获取所有学员的坐标
        /// </summary>
        List<GetMyClassmateMapDataModel> GetMyClassmateMapData(GetMyClassmateMapDataRequest req);

        /// <summary>
        /// 登出小程序
        /// </summary>
        int Logout(LogoutRequest req);

        /// <summary>
        /// 获取用户的详情
        /// </summary>
        /// <param name="userId">用户id</param>
        GetMyClassmateDeatilModel GetMyClassmateDeatil(int userId);

        /// <summary>
        /// 提交用户经纬度信息
        /// </summary>
        int SubmitUserPosition(SubmitUserPositionRequest req);

        /// <summary>
        /// 获取用户收藏的课程列表
        /// </summary>
        List<GetUserCollectCourseModel> GetUserCollectCourseList(GetUserCollectRequest req);

        /// <summary>
        /// 获取用户收藏的资讯列表
        /// </summary>
        List<GetUserCollectNewsModel> GetUserCollectNewsList(GetUserCollectRequest req);
    }
}
