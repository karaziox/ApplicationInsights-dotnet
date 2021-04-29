﻿namespace Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing
{
    using System;

    /// <summary>
    /// Self diagnostics class captures the EventSource events sent by Application Insights
    /// modules and writes them to local file for internal troubleshooting.
    /// </summary>
    public class SelfDiagnosticsModule : IDisposable
    {
        /// <summary>
        /// Long-living object that hold relevant resources.
        /// </summary>
        private static readonly SelfDiagnosticsModule Instance = new SelfDiagnosticsModule();

        // Long-living object that holds a refresher which checks whether the configuration file was updated
        // every 10 seconds.
        // private readonly SelfDiagnosticsConfigRefresher configRefresher;

        static SelfDiagnosticsModule()
        {
            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) =>
            {
                Instance.Dispose();
            };
        }

        private SelfDiagnosticsModule()
        {
            // this.configRefresher = new SelfDiagnosticsConfigRefresher();
        }

        /// <summary>
        /// Trigger CLR to initialize static fields and static constructors of SelfDiagnosticsModule.
        /// No member of SelfDiagnosticsModule class is explicitly called when an EventSource class, say
        /// AspNetCoreEventSource, is invoked to send an event.
        /// This method needs to be called in order to capture any EventSource event.
        /// </summary>
        public static void EnsureInitialized()
        {
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes config refresher.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // this.configRefresher.Dispose();
            }
        }
    }
}
