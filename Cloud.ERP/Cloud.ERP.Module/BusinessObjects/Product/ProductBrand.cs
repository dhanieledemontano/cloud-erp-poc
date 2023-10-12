using Cloud.ERP.Module.BusinessObjects.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Module.BusinessObjects.Product
{
    public class ProductBrand : VDBaseObject
    {
        #region Constructor
        public ProductBrand(Session session) : base(session) { }
        #endregion

        #region Properties
        public string Name
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Name), value);
        }

        public int BrandNo
        {
            get => GetPropertyValue<int>();
            set => SetPropertyValue(nameof(BrandNo), value);
        }

        public string Description
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Description), value);
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
