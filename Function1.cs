using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using TrackPoc;
using TrackPoc.CustomBindingAttribute;

[assembly: FunctionsStartup(typeof(Startup))]

namespace TrackPoc
{
    public  class Function1
    {
        private readonly IMyLogic _myLogic;

        public Function1(IMyLogic myLogic)
        {
            _myLogic = myLogic;
        }

        [FunctionName("Function1")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [My] string result)
        {
            _myLogic.Track();
            return new OkResult();
        }
    }

    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(builder);
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var webJobsBuilder = builder.Services.AddWebJobs(_ => { });

            webJobsBuilder.Services.AddTransient<IMyLogic, MyLogic>();

            webJobsBuilder.AddExtension<MyExtensionProvider>();
        }
    }
}
