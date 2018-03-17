using System.Web.Mvc;
using FrameWork.Common;
using FrameWork.Entity.ViewModel.SignIn;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    public class SignInController : AdminControllerBase
    {
        // GET: SignIn
        public ActionResult Index(GetSignInInfoRequest request)
        {
            var userIndo = RedisInfoHelper.GetRedisModel(request.Token);
            return null;
        }
    }
}