using Cloud.ERP.Module.BusinessObjects.Product;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cloud.ERP.Module;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Persistent.BaseImpl;

namespace Cloud.ERP.Blazor.Server.Controllers.Product
{
    
    public partial class ProductCategoryBaseController : ViewController
    {
        #region Constructor
        public ProductCategoryBaseController()
        {
            InitializeComponent();
            TargetViewType = ViewType.ListView;
            TargetObjectType = typeof(ProductCategoryBase);

            SimpleAction actionButton = new SimpleAction(this, "ProductCategoryBaseBtn", PredefinedCategory.View)
            {
                Caption = "Fetch list"
            };
            actionButton.Execute += GetProductBaseList_Execute;
        }
        #endregion


        #region Methods
        private void GetProductBaseList_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var os = this.ObjectSpace as XPObjectSpace;
            var uow = os.Session.CreateNewSession();
            //string sql = "SELECT * FROM [dbo].[ProductCategoryBase] WHERE [Oid] = @p0";
            //ParameterValue baseCatOid = new ParameterValue();
            //baseCatOid.DBTypeName = "guid";
            //baseCatOid.Value = "94D18150-180D-455E-BFD2-2D89C00CFDAC";
            //var result = uow.ExecuteScalar(sql, new QueryParameterCollection(baseCatOid));
            string sql = "'SELECT * FROM ProductCategoryBase'";
            var result = uow.ExecuteScalar(sql);

            uow.Dispose();

            if (result != null)
                ShowNotification("Success", InformationType.Success, "Data fetched");
            else
                ShowNotification("Error", InformationType.Error, "An error has occurred");

            ReloadTable(result);
        }

        private void ReloadTable(object example)
        {
            //var os = this.ObjectSpace as XPObjectSpace;
            //var uow = os.Session.CreateNewSession();
            //var currentObject = uow.Query<ProductCategoryBase>();
            //Console.WriteLine(currentObject.Count());

            //currentObject = (XPQuery<ProductCategoryBase>)example;
            //uow.CommitChanges();

            //var newItems = uow.Query<ProductCategoryBase>().Where(x => x.Name == "CategoryItem1").ToList();
            //newItems = example;
            //uow.CommitChanges();

            //Clears list via DataAccessMode Client
            //ListView list = this.View as ListView;
            //foreach (var item in list.SelectedObjects)
            //{
            //    list.CollectionSource.Remove(item);
            //}
            //list.Refresh();
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

        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        #endregion

    }
}
