using Cloud.ERP.Module.BusinessObjects.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Module
{
    public static class SessionExtensions
    {
        public static VDUnitOfWork CreateNewSession(this Session session) => new VDUnitOfWork(session.ServiceProvider, session.DataLayer);
    }
}
