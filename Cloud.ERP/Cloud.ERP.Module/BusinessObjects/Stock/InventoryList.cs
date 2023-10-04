using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using Cloud.ERP.Module.BusinessObjects.Product;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Stock
{
    public class InventoryList : VDBaseObject
    {
        #region Members

        private decimal _price;

        #endregion

        #region Constructor
        public InventoryList(Session session) : base(session) { }
        #endregion

        #region Properties
        [VisibleInDetailView(true), VisibleInListView(false), VisibleInLookupListView(false)]

        [Association("Product-InventoryListItems")]
        public ProductBase Product
        {
            get => GetPropertyValue<ProductBase>();
            set => SetPropertyValue(nameof(Product), value);
        }
        public string Name
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Name), value);
        }

        public string SerialNo
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(SerialNo), value);
        }

        public string Notes
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Notes), value);
        }

        public decimal Price
        {
            get => GetPropertyValue<decimal>();
            set => SetPropertyValue(nameof(Price), value);
        }

        public bool IsActive
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(nameof(IsActive), value);
        }

        public bool IsSold
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(nameof(IsSold), value);
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
