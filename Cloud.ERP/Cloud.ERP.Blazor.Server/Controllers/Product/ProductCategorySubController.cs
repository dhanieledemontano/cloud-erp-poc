using Cloud.ERP.Module;
using Cloud.ERP.Module.BusinessObjects.Configuration;
using Cloud.ERP.Module.BusinessObjects.Product;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Cloud.ERP.Blazor.Server.Controllers.Product
{
    public class ProductCategorySubController : ViewController
    {
        #region Constructor
        public ProductCategorySubController()
        {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(ProductCategoryBase);

            SimpleAction actionButton = new SimpleAction(this, "GetProductSubCatButton", "GetProductSubCat")
            {
                Caption = "Load Sub Categories(MSSQL)"
            };
            actionButton.Execute += GetProductSubCat_Execute;
        }
        #endregion

        #region Methods
        private void GetProductSubCat_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var os = this.ObjectSpace as XPObjectSpace;
            var uow = os.Session.CreateNewSession();
            string sql = "SELECT * FROM [dbo].[ProductCategorySub] WHERE [Category] = @p0";
            ParameterValue categoryOid = new ParameterValue();
            categoryOid.DBTypeName = "guid";
            categoryOid.Value = ((ProductCategoryBase)View.CurrentObject).Oid;
            var result = uow.ExecuteScalar(sql, new QueryParameterCollection(categoryOid));
            uow.Dispose();

            if (result != null)
                ShowNotification("Success", InformationType.Success, "Data fetched");
            else
                ShowNotification("Error", InformationType.Error, "An error has occurred");
            //ReloadTable();
        }

        private void ReloadTable()
        {
            ((ProductCategoryBase)View.CurrentObject).SubCategoryItems.Remove(((ProductCategoryBase)View.CurrentObject).SubCategoryItems[0]);
            ObjectSpace.SetModified(View.CurrentObject, View.ObjectTypeInfo.FindMember(nameof(ProductCategoryBase.SubCategoryItems)));
        }

        private void ShowNotification(string caption, InformationType informationType, string message)
        {
            MessageOptions options = new MessageOptions();
            options.Duration = 10000;
            options.Message = message;
            options.Type = informationType;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = caption;
            options.Win.Type = WinMessageType.Toast;
            Application.ShowViewStrategy.ShowMessage(options);
        }
        #endregion

    }
}
