using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace Cloud.ERP.Benchmark.PerformanceTests
{
    public class AntiVirusPassConfig : ManualConfig
    {
        public AntiVirusPassConfig()
        {
            AddJob(Job.ShortRun
                .WithToolchain(InProcessNoEmitToolchain.Instance));
        }
    }
}
