using Microsoft.Azure.WebJobs.Host.Config;

namespace TrackPoc.CustomBindingAttribute
{
    internal class MyExtensionProvider : IExtensionConfigProvider
    {
        private readonly IMyLogic _myLogic;

        public MyExtensionProvider(IMyLogic myLogic)
        {
            _myLogic = myLogic;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            var provider = new MyBindingProvider(_myLogic);
            var rule = context.AddBindingRule<MyAttribute>();
            rule.Bind(provider);
        }
    }
}