using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using Cloud.ERP.Module.BusinessObjects.Stock;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Product
{
    public class ProductCategoryBase : VDBaseObject
    {
        #region Constructor
        public ProductCategoryBase(Session session) : base(session) { }
        #endregion

        #region Properties
        [Association("Category-SubCategoryItems")]
        public XPCollection<ProductCategorySub> SubCategoryItems => GetCollection<ProductCategorySub>();

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

        public int CategoryNo
        {
            get => GetPropertyValue<int>();
            set => SetPropertyValue(nameof(CategoryNo), value);
        }
        #endregion
    }
}
