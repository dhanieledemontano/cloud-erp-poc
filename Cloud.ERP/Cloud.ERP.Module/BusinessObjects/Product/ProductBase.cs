using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using Cloud.ERP.Module.BusinessObjects.MasterData;
using Cloud.ERP.Module.BusinessObjects.Stock;
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
        [Association("Product-InventoryListItems")]
        public XPCollection<InventoryList> InventoryListItems => GetCollection<InventoryList>();

        public string Notes
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Notes), value);
        }

        public bool IsActive
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(nameof(IsActive), value);
        }

        public decimal TotalPrice
        {
            get
            {
                _itemSumPrice = InventoryListItems.Sum(x => x.Price);
                return _itemSumPrice;
            }
        }

        public decimal RemPrice
        {
            get
            {
                _itemSumPrice = InventoryListItems.Where(x => x.IsActive && x.IsSold == false).Sum(x => x.Price);
                return _itemSumPrice;
            }
        }

        public double? InventoryQuantity
        {
            get
            {
                _inventoryCount = InventoryListItems.Count != 0 ? InventoryListItems.Count(x => x.IsActive) : 0;
                return _inventoryCount;
            }
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
