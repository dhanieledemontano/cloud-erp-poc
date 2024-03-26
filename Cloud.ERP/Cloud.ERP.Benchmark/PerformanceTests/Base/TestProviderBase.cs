using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Benchmark.PerformanceTests.Base
{
    public abstract class TestProviderBase : IDisposable
    {
        public static bool CheckResultForDebug = true;

        public abstract void InsertContact(int recordsCount);

        public abstract void TearDownSession();

        public virtual void Dispose() => TearDownSession();
        
    }
}
