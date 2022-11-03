using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;

namespace TrackPoc.CustomBindingAttribute
{
    public interface IMyLogic
    {
        void Track();
    }

    internal class MyLogic : IMyLogic
    {
        private readonly TelemetryClient _telemetryClient;

        public MyLogic(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public void Track()
        {
            // Working
            _telemetryClient.TrackTrace("Working", SeverityLevel.Information);

            // Not working
            // When APPINSIGHTS_INSTRUMENTATIONKEY not configured: Application Insights Telemetry (unconfigured): {"name":"AppDependencies","time":"2022-11-03T13:25:31.4313764Z","tags":{"ai.cloud.roleInstance":"*","ai.internal.sdkVersion":"azurefunctionscoretools: 4.0.4829"},"data":{"baseType":"RemoteDependencyData","baseData":{"ver":2,"name":"http://localhost","id":"99b12e28faa02df9","data":"/api","duration":"00:00:00.1000000","success":true,"type":"HTTP"}}}
            _telemetryClient.TrackDependency("HTTP", "http://localhost", "/api", DateTime.UtcNow, TimeSpan.FromMilliseconds(100), true);
        }
    }
}
