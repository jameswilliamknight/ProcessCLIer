using System;
using AppKill.Core;
using AppKill.Workflow.Types;

namespace AppKill.Workflow
{
    /// <see cref="AppMode.SilentKill"/>
    internal class SilentKill : IWorkflowUnit
    {
        private readonly AppArgs _appArgs;

        public SilentKill(AppArgs appArgs)
        {
            _appArgs = appArgs;
        }

        public int Run()
        {
            var killList = _appArgs.KillList.ToArray();

            var processToEnd = ProcessRepository
                .GetProcesses(false)
                .Filter(killList);

            Console.WriteLine($"{processToEnd.Length} processes killed.");

            foreach (var processName in ProcessRepository.EndProcesses(processToEnd, ProcessAction.Exit))
            {
                if (_appArgs.Verbose)
                {
                    Console.WriteLine($"Killed {processName}");
                }
            }
            
            return 0;
        }
    }
}