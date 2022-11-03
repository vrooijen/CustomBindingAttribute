using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Threading.Tasks;

namespace TrackPoc.CustomBindingAttribute
{
    internal class MyBindingProvider : IBindingProvider
    {
        private readonly IMyLogic _myLogic;

        public MyBindingProvider(IMyLogic myLogic)
        {
            _myLogic = myLogic;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new MyBinding(_myLogic);
            return Task.FromResult(binding);
        }
    }
}