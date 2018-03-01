namespace FrameWork.Entity.ViewModel.Course
{
    /// <summary>
    /// 收藏资讯的接口
    /// </summary>
    public class GetFreeVideoRequest
    {
        public int IndustryId { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
