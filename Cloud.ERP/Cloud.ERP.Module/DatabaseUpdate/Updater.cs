using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using Cloud.ERP.Module.BusinessObjects.User;

namespace Cloud.ERP.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        //string name = "MyName";
        //DomainObject1 theObject = ObjectSpace.FirstOrDefault<DomainObject1>(u => u.Name == name);
        //if(theObject == null) {
        //    theObject = ObjectSpace.CreateObject<DomainObject1>();
        //    theObject.Name = name;
        //}

        //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).

        //var mssqlConn = ObjectSpace.FirstOrDefault<ConfigDb>(x => x.ConnectionName == "Microsoft SQL");
        //if (mssqlConn is null)
        //{
        //    mssqlConn = ObjectSpace.CreateObject<ConfigDb>();
        //    mssqlConn.ConnectionName = "Microsoft SQL";
        //    mssqlConn.ConnectionValue = "XpoProvider=MSSqlServer;User=sa;Password=1t_r3publ1c;Pooling=false;Data Source=localhost,1533;Initial Catalog=ExampleDb;Encrypt=False";
        //    mssqlConn.IsActive = true;
        //}
        //var postgresConn = ObjectSpace.FirstOrDefault<ConfigDb>(x => x.ConnectionName == "Postgres");
        //if (postgresConn is null)
        //{
        //    postgresConn = ObjectSpace.CreateObject<ConfigDb>();
        //    postgresConn.ConnectionName = "Postgres";
        //    postgresConn.ConnectionValue = "XpoProvider=Postgres;Host=localhost;Port=5532;User ID=postgres;Password=1t_r3publ1c;Database=ExampleDb;Encoding=UNICODE";
        //    postgresConn.IsActive = true;
        //}

        ApplicationUser sampleUser = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "User");
        if (sampleUser == null)
        {
            sampleUser = ObjectSpace.CreateObject<ApplicationUser>();
            sampleUser.UserName = "User";
            sampleUser.SetPassword("");

            ObjectSpace.CommitChanges(); 
            ((ISecurityUserWithLoginInfo)sampleUser).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(sampleUser));
        }
        PermissionPolicyRole defaultRole = CreateDefaultRole();
        sampleUser.Roles.Add(defaultRole);

        ApplicationUser userAdmin = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "Admin");
        if (userAdmin == null)
        {
            userAdmin = ObjectSpace.CreateObject<ApplicationUser>();
            userAdmin.UserName = "Admin";

            userAdmin.SetPassword("");

            ((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userAdmin));
        }
       
        PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Administrators");
        if (adminRole == null)
        {
            adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
            adminRole.Name = "Administrators";
        }
        adminRole.IsAdministrative = true;
        userAdmin.Roles.Add(adminRole);

        ObjectSpace.CommitChanges(); 
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
        //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
        //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
        //}
    }

    private PermissionPolicyRole CreateDefaultRole()
    {
        PermissionPolicyRole defaultRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(role => role.Name == "Default");
        if (defaultRole == null)
        {
            defaultRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
            defaultRole.Name = "Default";

            defaultRole.AddObjectPermissionFromLambda<ApplicationUser>(SecurityOperations.Read, cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
            defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
            defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
            defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "StoredPassword", cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
            defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
            defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
            defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
            defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
            defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);
        }
        return defaultRole;
    }
}
