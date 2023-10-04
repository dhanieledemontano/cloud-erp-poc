using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Module.BusinessObjects.Base;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Stock
{
    public class Inventory : VDBaseObject
    {
        #region Constructor
        public Inventory(Session session) : base(session) { }
        #endregion

        #region Properties
        [RuleRequiredField("RuleRequiredField for Inventory.Name", DefaultContexts.Save)]
        public string Name
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(nameof(Name), value);
        }

        [NonCloneable]
        [RuleRequiredField("RuleRequiredField for Inventory.Date", DefaultContexts.Save)]
        public DateTime Date
        {
            get => GetPropertyValue<DateTime>();
            set => SetPropertyValue(nameof(Date), value);
        }
        #endregion
    }
}
