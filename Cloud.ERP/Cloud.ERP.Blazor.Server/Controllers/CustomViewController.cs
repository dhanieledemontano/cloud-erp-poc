using Cloud.ERP.Module.BusinessObjects.Configuration;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace Cloud.ERP.Blazor.Server.Controllers
{
    public class CustomViewController : ViewController
    {
        #region Members
        //public IConfiguration Configuration { get; }
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
            //Configuration = configuration;
        }
        #endregion

        #region Methods

        private void ActionButton_Execute(Object sender, SimpleActionExecuteEventArgs e)
        {
            Console.WriteLine("test button");
            //string connectionString = null;
            //if (Configuration.GetConnectionString("ConnectionString") is not null)
            //{
            //    connectionString = Configuration.GetConnectionString("ConnectionString");
            //}

            //Console.WriteLine("Connection is: " + connectionString);
        }
        #endregion
    }
}
