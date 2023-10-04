using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Cloud.ERP.Module.BusinessObjects.Base
{
    [NonPersistent]
    public class VDBaseObject : VDLiteBaseObject
    {
        #region Members
        internal static readonly IList<string> SystemMembers;

        [Persistent(nameof(CreatedOn)), NonCloneable]
        private DateTime _createdOn = DateTime.Now;

        [Persistent(nameof(ModifiedOn)), NonCloneable]
        private DateTime _modifiedOn;

        #endregion

        #region Constructor

        public VDBaseObject(Session session) : base(session) { }
        
        #endregion

        #region Properties
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        [ModelDefault(nameof(IModelCommonMemberViewItem.EditMask), "G"), ModelDefault(nameof(IModelCommonMemberViewItem.DisplayFormat), "{0:G}")]
        [NonCloneable, PersistentAlias(nameof(_createdOn))]
        public DateTime CreatedOn => CreatedOn;

        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        [ModelDefault(nameof(IModelCommonMemberViewItem.EditMask), "G"), ModelDefault(nameof(IModelCommonMemberViewItem.DisplayFormat), "{0:G}")]
        [NonCloneable, PersistentAlias(nameof(_modifiedOn))]
        public DateTime ModifiedOn => this._modifiedOn;

        #endregion
    }
}
