

namespace FrameWork.Entity.ViewModel.Account
{
    /// <summary>
    /// 接口参数
    /// </summary>
    public class SubmitUserPositionRequest
    {
        /// <summary>
        /// 学员用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { set; get; }
    }
}
