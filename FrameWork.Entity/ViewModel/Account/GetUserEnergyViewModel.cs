namespace FrameWork.Entity.ViewModel.Account
{
    public class GetUserEnergyRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }
    }

    /// <summary>
    /// 获取用户的能量值
    /// </summary>
    public class GetUserEnergyViewModel
    {
        /// <summary>
        /// 学员的能量值
        /// </summary>
        public int EnergyCount { set; get; }
    }
}
