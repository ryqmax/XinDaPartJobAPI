using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.PageHelper;

namespace App.Common.PageHelper
{
    public class PagerInfo
    {
        public int RecordCount { get; set; }

        private int _currentPageIndex;
        public int CurrentPageIndex 
        { 
            get
            {
                if (this._currentPageIndex == 0)
                {
                    this._currentPageIndex = 1;
                }
                return this._currentPageIndex;
            }
            set
            {
                this._currentPageIndex = value;
            }
        }

        private int _pageSize;
        public int PageSize 
        {
            get
            {
                if (this._pageSize == 0)
                {
                    this._pageSize = PagerHelper.DEFAULT_PAGE_SIZE;
                }
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
            }
        }

    }
}
