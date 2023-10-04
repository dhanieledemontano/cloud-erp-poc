using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Product
{
    public class ProductCategory : VDBaseObject
    {
        #region Constructor
        public ProductCategory(Session session) : base(session) { }
        #endregion

        #region Properties

        public string Name
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Name), value);
        }

        #endregion
    }
}
