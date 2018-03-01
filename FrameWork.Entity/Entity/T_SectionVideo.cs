using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    /// <summary>
    /// 章节视频表
    /// </summary>
    [TableName("T_SectionVideo") ]
    [PrimaryKey("Id", true) ]
    public class T_SectionVideo
    {
        public  int Id { get; set; }
        public string Name { get; set; } 
        public  int SectionId { get; set; }
        public int TeacherId { get; set; }
        public int VideoLibraryId { get; set; }
        public bool IsFree { get; set; }
        public double Price { get; set; }
        public string Lecture { get; set; }
        public int Sequence { get; set; }
        public int BuyCount { get; set; }
        public int BrowseCount { get; set; }
        public int PraiseCount { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDel { get; set; }
        public int ModifyUserId { get; set; }
        public DateTime ModifyTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string VideoImgPath { get; set; }
    }
}
