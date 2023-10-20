using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata.Helpers;
using DevExpress.Xpo.Metadata;

namespace Cloud.ERP.Module.BusinessObjects.Base
{
    public class VDUnitOfWork : UnitOfWork
    {
        public VDUnitOfWork(IServiceProvider serviceProvider, IDataLayer layer, params IDisposable[] disposeOnDisconnect)
            : base(serviceProvider, layer, disposeOnDisconnect)
        {
        }

        public VDUnitOfWork(IServiceProvider serviceProvider, IObjectLayer layer, params IDisposable[] disposeOnDisconnect)
            : base(serviceProvider, layer, disposeOnDisconnect)
        {
        }

        protected override MemberInfoCollection GetPropertiesListForUpdateInsert(object theObject, bool isUpdate, bool addDelayedReference)
        {
            if (theObject is VDLiteBaseObject supportChangedMembers && !this.IsNewObject(supportChangedMembers))
            {
                var classInfo = this.GetClassInfo(supportChangedMembers);
                var changedMembers = new MemberInfoCollection(classInfo);
                var memberInfos = base.GetPropertiesListForUpdateInsert(supportChangedMembers, isUpdate, addDelayedReference).Where(m => this.MemberHasChanged(supportChangedMembers, m));
                changedMembers.AddRange(memberInfos);

                return changedMembers;
            }

            return base.GetPropertiesListForUpdateInsert(theObject, isUpdate, addDelayedReference);
        }

        private bool MemberHasChanged(VDLiteBaseObject supportChangedMembers, XPMemberInfo m)
        {
            return m.HasAttribute(typeof(PersistentAttribute)) || m.IsKey || m is ServiceField || supportChangedMembers.ChangedProperties.Contains(m.Name);
        }
    }
}
