using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Base
{
    [NonPersistent]
    public class VDLiteBaseObject : XPCustomObject
    {
        #region Members
        private HashSet<string> _changedProperties;
        private List<string> _lastChangedProperties;
        private Guid _oid = Guid.Empty;
        #endregion

        #region Constructor
        public VDLiteBaseObject(Session session) : base(session) { }
        #endregion

        #region Events
        public static EventHandler OnObjectAfterConstruction;
        public static EventHandler OnObjectSaving;
        public static EventHandler OnObjectSaved;
        public static EventHandler<ObjectChangedEventArgs> OnObjectChanged;
        #endregion

        #region Properties
        [PersistentAlias(nameof(_oid)), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public Guid Oid => _oid;

        [NonCloneable, NonPersistent, Browsable(false)]
        public HashSet<string> ChangedProperties
        {
            get
            {
                _changedProperties ??= new HashSet<string>();
                return _changedProperties;
            }
            set => _changedProperties = value;
        }

        [Browsable(false)]
        public bool HasChanges => ChangedProperties.Count > 0;

        [NonCloneable, Browsable(false)]
        public List<string> LastChangedProperties
        {
            get
            {
                _lastChangedProperties ??= new List<string>();
                return _lastChangedProperties;
            }
        }

        [Browsable(false)]
        public bool IsNewObject => Session.IsNewObject(this);

        [Browsable(false)]
        public IServiceProvider ServiceProvider => Session.ServiceProvider;
        #endregion

        #region Methods

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        #endregion
    }
}
