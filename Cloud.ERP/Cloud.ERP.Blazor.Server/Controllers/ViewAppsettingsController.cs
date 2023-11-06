using Cloud.ERP.Module.BusinessObjects.Configuration;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Dynamic;
using DevExpress.ExpressApp.Editors;

namespace Cloud.ERP.Blazor.Server.Controllers
{
    public class ViewAppsettingsController : ViewController
    {
        #region Constructor

        public ViewAppsettingsController()
        {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(ConfigDb);

            SimpleAction actionButton = new SimpleAction(this, "ViewAppSettingsButton", "ViewSettings")
            {
                Caption = "View Connection Settings",
                ConfirmationMessage = "View connection settings?"
            };
            actionButton.Execute += ViewAppSettings_Execute;
        }
        #endregion

        #region Methods

        private void ViewAppSettings_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ShowNotification();
        }

        private string ViewSettings()
        {
            var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());

            dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
            return config.ConnectionStrings.ConnectionString;
        }

        private void ShowNotification()
        {
            MessageOptions options = new MessageOptions();
            options.Duration = 10000;
            options.Message = "Task successfully executed! Connection: " + ViewSettings();
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Toast;
            options.OkDelegate = () => {
                IObjectSpace os = Application.CreateObjectSpace(typeof(ConfigDb));
                DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ConfigDb>());
                Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
            };
            Application.ShowViewStrategy.ShowMessage(options);
        }

        #endregion
    }
}
