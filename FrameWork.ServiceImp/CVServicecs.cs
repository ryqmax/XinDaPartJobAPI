using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    public class CVServicecs : BaseService<T_UserShieldCV>, ICVServicecs
    {
        /// <summary>
        /// 用户屏蔽简历
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="cVId">简历Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        public bool UserShieldCV(int userId, int cVId, int shieldDay)
        {
            var sql = @"INSERT dbo.T_UserShieldCV
                                ( UserId ,
                                  CVId ,
                                  TimeSpan ,
                                  EndTime ,
                                  IsDel ,
                                  CreateUserId ,
                                  CreateTime
                                )
                        VALUES  ( @userId , -- UserId - int
                                  @cVId , -- CVId - int
                                  @shieldDay , -- TimeSpan - int
                                  GETDATE() , -- EndTime - date
                                  0 , -- IsDel - bit
                                  @userId , -- CreateUserId - int
                                  GETDATE()  -- CreateTime - datetime
                                )";
            return DbPartJob.Execute(sql,new{userId,cVId,shieldDay})>0;
        }

        /// <summary>
        /// 企业屏蔽简历
        /// </summary>
        /// <param name="epId">企业Id</param>
        /// <param name="cVId">简历Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        public bool EnterpriseShieldCV(int epId, int cVId, int shieldDay)
        {
            var sql = @"INSERT dbo.T_EPShieldCV
                                ( EnterpriseId ,
                                  CVId ,
                                  TimeSpan ,
                                  EndTime ,
                                  IsDel ,
                                  CreateUserId ,
                                  CreateTime
                                )
                        VALUES  ( @epId , -- EnterpriseId - int
                                  @cVId , -- CVId - int
                                  @shieldDay , -- TimeSpan - int
                                  GETDATE() , -- EndTime - date
                                  0 , -- IsDel - bit
                                  @epId , -- CreateUserId - int
                                  GETDATE()  -- CreateTime - datetime
                                )";
            return DbPartJob.Execute(sql, new { epId, cVId, shieldDay }) > 0;
        }
    }
}
