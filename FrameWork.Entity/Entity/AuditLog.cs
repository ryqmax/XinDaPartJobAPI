using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("AuditLog")]
    [PrimaryKey("Id")]
    public class AuditLog
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string UserName {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string ModuleName {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string TableName {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public int? ModelId {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string EventType {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string NewValues {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public DateTime? CreateTime {get;set;}

    }
}
