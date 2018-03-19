using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPAccount")]
    [PrimaryKey("Id")]
    public class T_EPAccount
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
        /// 子账号手机号 
        /// </summary>
        public string Phone {get;set;}

        /// <summary>
        /// 权限id字符串 
        /// </summary>
        public string PermissionIds {get;set;}

        /// <summary>
        /// 账号类型，1：主账号，2.子账号
        /// </summary>
        public byte Type {get;set;}

        /// <summary>
        /// 账号状态：0.禁用，1.启用，2.违规禁用
        /// </summary>
        public byte Status { get;set;}

        /// <summary>
        /// 备注：禁用理由或其他
        /// </summary>
        public string Note { set; get; }

        /// <summary>
        /// 是否删除 
        /// </summary>
        public bool IsDel {get;set;}

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
