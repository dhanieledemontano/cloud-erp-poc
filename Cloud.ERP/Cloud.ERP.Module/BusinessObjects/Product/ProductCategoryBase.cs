using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using Cloud.ERP.Module.BusinessObjects.Stock;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit.Model;
using Console = System.Console;

namespace Cloud.ERP.Module.BusinessObjects.Product
{
    public class ProductCategoryBase : VDBaseObject
    {
        #region Members
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        public XPCollection<ProductCategorySub> fSubCategoryItems;

        #endregion
        #region Constructor

        public ProductCategoryBase(Session session) : base(session)
        {
            Console.WriteLine("test");
        }
        #endregion

        #region Events

        public event ObjectManipulationEventHandler ObjectLoaded;

        #endregion

        #region Properties

        [Association("Category-SubCategoryItems")]
        public XPCollection<ProductCategorySub> SubCategoryItems => GetCollection<ProductCategorySub>();
        //public XPCollection<ProductCategorySub> SubCategoryItems
        //{
        //    get
        //    {
        //        if (fSubCategoryItems == null)
        //        {
        //            fSubCategoryItems = new XPCollection<ProductCategorySub>(Session);
        //            if(Session.IsObjectsLoading)
        //                Console.WriteLine("Loading");
        //        }
        //        return fSubCategoryItems;
        //    }
        //}



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
