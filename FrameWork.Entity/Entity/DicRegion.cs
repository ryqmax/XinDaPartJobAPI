using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("DicRegion")]
    [PrimaryKey("Id")]
    public class DicRegion
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public string Id {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public Byte Grade {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string ParentId {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string Description {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string DescriptionEng {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public int? OrderNo {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string FullName {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string MapBarName {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public decimal? Lng {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public decimal? Lat {get;set;}

        /// <summary>
        /// - 
        /// </summary>
        public string Abbr {get;set;}

    }
}
