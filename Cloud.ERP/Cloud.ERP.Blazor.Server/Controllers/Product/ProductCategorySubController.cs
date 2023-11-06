using Cloud.ERP.Module;
using Cloud.ERP.Module.BusinessObjects.Configuration;
using Cloud.ERP.Module.BusinessObjects.Product;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.ERP.Blazor.Server.Controllers.Product
{
    public class ProductCategorySubController : ViewController
    {
        #region Constructor
        public ProductCategorySubController()
        {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(ProductCategorySub);

            SimpleAction actionButton = new SimpleAction(this, "GetProductSubCatButton", "GetProductSubCat");
            actionButton.Execute += GetProductSubCat_Execute;
        }
        #endregion

        #region Methods
        private void GetProductSubCat_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var os = this.ObjectSpace as XPObjectSpace;
            var uow = os.Session.CreateNewSession();
            string sql = "SELECT * FROM [dbo].[ProductCategorySub] WHERE [Oid] = '" + ((ProductCategorySub)View.CurrentObject).Oid + "'";
            uow.ExecuteNonQuery(sql);
        }
        #endregion

    }
}
