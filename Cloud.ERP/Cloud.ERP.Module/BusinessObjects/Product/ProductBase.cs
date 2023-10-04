using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using Cloud.ERP.Module.BusinessObjects.MasterData;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Product
{
    public class ProductBase : VDBaseObject
    {
        #region Members
        private Lazy<string> _localizedName;
        private double? _inventoryCount;
        private decimal _itemSumPrice;
        #endregion

        #region Constructor
        public ProductBase(Session session) : base(session) { }
        #endregion

        #region Properties
        [MemberDesignTimeVisibility(false), PersistentAlias(MasterDataBase.LocalizationAlias)]
        public string LocalizedName
        {
            get
            {
                _localizedName ??= new Lazy<string>(() => EvaluateAlias().ToString());
                return _localizedName.Value;
            }
        }

        public ProductBrand Brand
        {
            get => GetPropertyValue<ProductBrand>();
            set => SetPropertyValue(nameof(Brand), value);
        }
        public ProductCategory Category
        {
            get => GetPropertyValue<ProductCategory>();
            set => SetPropertyValue(nameof(Category), value);
        }

        #endregion
    }
}
