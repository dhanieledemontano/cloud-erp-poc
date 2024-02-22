using Cloud.ERP.Module;
using Cloud.ERP.Module.BusinessObjects.Configuration;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraRichEdit.Model;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Data.SqlClient;
using System.Dynamic;
using DevExpress.DataAccess.Native.Web;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using DevExpress.Xpo.DB;

namespace Cloud.ERP.Blazor.Server.Controllers
{
    public class CustomViewController : ViewController
    {

        #region Constructor

        public CustomViewController()
        {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(ConfigDb);

            SimpleAction actionButton = new SimpleAction(this, "ActionButton", "SetDatabase")
            {
                Caption = "Set Database",
                ConfirmationMessage = "Set database connection?"
            };
            actionButton.Execute += ActionButton_Execute;
        }
        #endregion

        #region Methods
        private void ActionButton_Execute(Object sender, SimpleActionExecuteEventArgs e)
        {
            var os = this.ObjectSpace as XPObjectSpace;
            var uow = os?.Session.CreateNewSession();
            //string sql = "UPDATE [dbo].[ConfigDb] SET [IsActive] = @p0 WHERE [Oid] = @p1";

            ParameterValue isActiveParam = new ParameterValue();
            isActiveParam.DBTypeName = "int";
            isActiveParam.Value = true;
            
            ParameterValue oIdParam = new ParameterValue();
            oIdParam.DBTypeName = "guid";
            oIdParam.Value = ((ConfigDb)View.CurrentObject).Oid;
            //uow.ExecuteNonQuery(sql, new QueryParameterCollection(isActiveParam, oIdParam));

            //string sqlselect = "SELECT * FROM [dbo].[ConfigDb]";
            string sqlselect = "SELECT * FROM \"ConfigDb\" ";
            var result = uow.ExecuteQuery(sqlselect);
            foreach (var item in result.ResultSet[0].Rows)
            {
                if ((Guid)item.Values[0] != ((ConfigDb)View.CurrentObject).Oid)
                {
                    isActiveParam.Value = false;
                    oIdParam.Value = (Guid)item.Values[0];
                    //string sqlUpd = "UPDATE [dbo].[ConfigDb] SET [IsActive] = @p0 WHERE [Oid] = @p1";
                    //uow.ExecuteNonQuery(sqlUpd, new QueryParameterCollection(isActiveParam, oIdParam));
                }
            }

            ((ConfigDb)View.CurrentObject).IsActive = true;

            #region Testing code
            //string sql = "SELECT * FROM [dbo].[ConfigDb]";
            //var result = uow.ExecuteQuery(sql);

            //var table = new List<ResultData>();
            //foreach (var item in result.ResultSet[0].Rows)
            //{
            //    var info = new ResultData();
            //    info.Oid = (Guid)item.Values[0];
            //    info.ConnectionName = item.Values[1].ToString();
            //    info.ConnectionValue = item.Values[2].ToString();
            //    info.IsActive = (bool)item.Values[3];
            //    Console.WriteLine(info.ConnectionName + " " + info.ConnectionValue);
            //    table.Add(info);
            //}
            #endregion

            uow.Dispose();
            bool isCompleted = UpdateAppsettings(((ConfigDb)View.CurrentObject).ConnectionValue);
            if (isCompleted)
                ShowNotification("Success", InformationType.Success, "Database connection successfully updated");
            else
                ShowNotification("Error", InformationType.Error, "An error has occurred");
        }

        private bool UpdateAppsettings(string connectionValue)
        {
            var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());

            dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
            config.ConnectionStrings.ConnectionString = connectionValue;
            config.ConnectionStrings.EasyTestConnectionString = connectionValue;

            var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);
            Task writeToFile = WriteToFile(appSettingsPath, newJson);
            if (writeToFile.IsCompleted)
                return true;
            return false;
        }

        Task WriteToFile(string appSettingsPath, dynamic newJson)
        {
            File.WriteAllText(appSettingsPath, newJson);
            return Task.CompletedTask;
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

    public class ResultData
    {
        public Guid Oid { get; set; }
        public string ConnectionName { get; set;  }
        public string ConnectionValue { get; set; }
        public bool IsActive { get; set; }
    }
}
