﻿using System;
using System.Reflection;
using AppKill.Workflow.Types;

namespace AppKill.Workflow
{
    /// <summary>
    ///     http://www.schweikhardt.net/man_page_howto.html
    /// </summary>
    /// <see cref="AppMode.Help"/>
    internal class Help : IWorkflowUnit
    {
        private readonly AppArgs _appArgs;

        public Help(AppArgs appArgs)
        {
            _appArgs = appArgs;
        }

        // TODO: Output README.md to console with basic formatting
        public int Run()
        {
            if (_appArgs.InteractiveMode)
            {
                Console.Clear();
            }

            var appName = Assembly.GetExecutingAssembly().GetName().Name + ".exe";

            Console.WriteLine(@"Interactive mode");
            Console.WriteLine(@"Displays an interactive menu");
            Console.WriteLine(@"flag: i, interactive");
            Console.WriteLine($"> {appName} - i");
            Console.WriteLine();
            Console.WriteLine(@"Listing mode");
            Console.WriteLine(@"Lists currently running processes");
            Console.WriteLine(@"flag: l, list");
            Console.WriteLine($"> {appName} - l");
            Console.WriteLine();
            Console.WriteLine(@"Silent Kill mode");
            Console.WriteLine(@"Kills the provided list of process names");
            Console.WriteLine(@"flag: k, kill");
            Console.WriteLine($"> {appName} - k spotify chrome");

            if (_appArgs.InteractiveMode)
            {
                Console.ReadKey();
            }

            return 0;
        }
    }
}