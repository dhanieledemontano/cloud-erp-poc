using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Configuration
{
    public class ConfigDb : VDLiteBaseObject
    {
        #region Constructor
        public ConfigDb(Session session) : base(session) { }
        #endregion

        #region Properties
        public string ConnectionName
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(ConnectionName), value);
        }

        [VisibleInListView(true)]
        //[Size(SizeAttribute.Unlimited)]
        [Size(255)]
        public string ConnectionValue
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(ConnectionValue), value);
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
