using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_LoginLog")]
    [PrimaryKey("Id")]
    public class T_LoginLog
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 会话id 
        /// </summary>
        public string LoginToken {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public int? UserId {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string UserName {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string ClientIP {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public DateTime? CreateTime {get;set;}

    }
}
