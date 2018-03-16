using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPHiringManager")]
    [PrimaryKey("Id")]
    public class T_EPHiringManager
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 企业id 
        /// </summary>
        public int EnterpriseId {get;set;}

        /// <summary>
        /// 名称或称呼 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone {get;set;}

        /// <summary>
        /// 头像地址 
        /// </summary>
        public string HeadPicUrl {get;set;}

        /// <summary>
        /// 认证状态：0.未认证，1.认证成功 
        /// </summary>
        public Byte AuthStatus {get;set;}

        /// <summary>
        /// 是否删除 
        /// </summary>
        public Boolean IsDel {get;set;}

        /// <summary>
        /// 编辑人id 
        /// </summary>
        public int ModifyUserId {get;set;}

        /// <summary>
        /// 编辑时间 
        /// </summary>
        public DateTime ModifyTime {get;set;}

        /// <summary>
        /// 创建人id 
        /// </summary>
        public int CreateUserId {get;set;}

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateTime {get;set;}

    }
}
