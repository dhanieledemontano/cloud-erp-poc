using Cloud.ERP.Module;
using Cloud.ERP.Module.BusinessObjects.Configuration;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit.Model;
using Microsoft.Extensions.Configuration.Json;

namespace Cloud.ERP.Blazor.Server.Controllers
{
    public class CustomViewController : ViewController
    {
        #region Members
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor

        public CustomViewController()
        {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(ConfigDb);

            SimpleAction actionButton = new SimpleAction(this, "ActionButton", "SetDatabase")
            {
                Caption = "Set Database",
                ConfirmationMessage = "Set database connection?",
            };
            actionButton.Execute += ActionButton_Execute;
        }
        #endregion

        #region Methods
        private void ActionButton_Execute(Object sender, SimpleActionExecuteEventArgs e)
        {
            Console.WriteLine("test button");
            var os = this.ObjectSpace as XPObjectSpace;
            var uow = os.Session.CreateNewSession();
            string sql = "SELECT * FROM [dbo].[ConfigDb]";
            var result = uow.ExecuteQuery(sql);

            var table = new List<ResultData>();
            foreach (var item in result.ResultSet[0].Rows)
            {
                var info = new ResultData();
                info.Oid = (Guid)item.Values[0];
                info.ConnectionName = item.Values[1].ToString();
                info.ConnectionValue = item.Values[2].ToString();
                info.IsActive = (bool)item.Values[3];
                Console.WriteLine(info.ConnectionName + " " + info.ConnectionValue);
                table.Add(info);
            }
        }
        #endregion
    }

    public class ResultData
    {
        public Guid Oid { get; set; }
        public string ConnectionName { get; set;  }
        public string ConnectionValue { get; set; }

        public bool IsActive { get; set; }
    }
}
