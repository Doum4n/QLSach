﻿using QLSach.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.component
{
    public class FormInitilize
    {
        private DashBoard _DashBoard;
        private recentUpdate _recentUpdate;
        private BookDetail _bookDetail;

        public FormInitilize(){

        }

        public DashBoard DashBoard {
            get {
                //_DashBoard ??= new();
                return new(); 
            } 
        }
        public recentUpdate RecentUpdate {
            get {return new() ; } 
        }
        public BookDetail BookDetail {
            get { _bookDetail ??= new(); return _bookDetail; }
        }
    }
}
