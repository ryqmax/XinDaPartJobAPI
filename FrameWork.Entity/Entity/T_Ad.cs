using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_Ad")]
    [PrimaryKey("Id")]
    public class T_Ad
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 广告区类型： 
        /// </summary>
        public Byte Type {get;set;}

        /// <summary>
        /// 广告描述 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 图片地址 
        /// </summary>
        public string PicUrl {get;set;}

        /// <summary>
        /// 总投放个数，上限 
        /// </summary>
        public int MaxCount {get;set;}

        /// <summary>
        /// 切换频率，单位：秒，15秒一次 
        /// </summary>
        public int SwitchSpan {get;set;}

        /// <summary>
        /// 单价，1200元 
        /// </summary>
        public Decimal Price {get;set;}

        /// <summary>
        /// 是否启用 
        /// </summary>
        public Boolean IsUsed {get;set;}

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
