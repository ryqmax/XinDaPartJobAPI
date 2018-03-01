using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Common.PageHelper
{
    public class PagerQuery<TPager,TEntity>
    {
        public PagerQuery(TPager pager, TEntity entity)
        {
            this.Pager = pager;
            this.EntityList = entity;
        }
        public TPager Pager { get; set; }
        public TEntity EntityList { get; set; } 
    }
}
