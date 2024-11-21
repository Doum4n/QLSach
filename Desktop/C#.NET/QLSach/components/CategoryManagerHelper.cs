using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.Components
{
    public class CategoryManagerHelper
    {
        public event Action OnAddCategory;
        public event Action OnModifyCategory;
        public event Action OnCancel;
        public event Action OnSave;
        public event Action OnDelete;

        public CategoryManagerHelper()
        {
            
        }

        public void Add()
        {
            OnAddCategory?.Invoke();
        }
        public void Modify()
        {
            OnModifyCategory?.Invoke();
        }
        public void Cancel()
        {
            OnCancel?.Invoke();
        }
        public void Save()
        {
            OnSave?.Invoke();
        }

        public void Delete()
        {
            OnDelete?.Invoke();
        }
    }
}
