using QLSach.view;
using QLSach.view.components.items;
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
        private PaneMostView _paneMostView;
        private PanePopular _panePopular;
        private PaneRecent _paneRecent;

        public FormInitilize(){

        }

        public DashBoard DashBoard {
            get {
                _DashBoard ??= new();
                return _DashBoard; 
            } 
        }
        public recentUpdate RecentUpdate {
            get { _recentUpdate ??= new();  return _recentUpdate ; } 
        }
        public BookDetail BookDetail {
            get { _bookDetail ??= new(); return _bookDetail; }
        }

        public PaneMostView PaneMostView 
        { 
            get {
                _paneMostView ??= new();
                return _paneMostView; 
            } 
            set => _paneMostView = value; 
        }
        public PanePopular PanePopular {
            get { _panePopular ??= new(); return _panePopular; }
            set => _panePopular = value; 
        }
        public PaneRecent PaneRecent {
            get { _paneRecent ??= new(); return _paneRecent; }
            set => _paneRecent = value; 
        }
    }
}
