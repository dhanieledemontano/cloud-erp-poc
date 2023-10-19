using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Product
{
    public class ProductCategorySub : VDBaseObject
    {
        #region Constructor
        public ProductCategorySub(Session session) : base(session) { }
        #endregion

        #region Properties
        [Association("Category-SubCategoryItems")]
        public ProductCategoryBase Category
        {
            get => GetPropertyValue<ProductCategoryBase>();
            set => SetPropertyValue(nameof(Category), value);
        }

        public string Name
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Name), value);
        }

        public string Description  
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Description), value);
        }

        public string Notes
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Notes), value);
        }

        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        public int SubCategoryNo
        {
            get => GetPropertyValue<int>();
            set => SetPropertyValue(nameof(SubCategoryNo), value);
        }

        public bool IsActive
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(nameof(IsActive), value);
        }
        #endregion

        #region Methods
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;
        }
        #endregion
    }
}
