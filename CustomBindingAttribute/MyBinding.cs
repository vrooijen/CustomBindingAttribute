using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System;
using System.Threading.Tasks;

namespace TrackPoc.CustomBindingAttribute
{
    internal class MyBinding : IBinding
    {
        private readonly IMyLogic _myLogic;

        public MyBinding(IMyLogic myLogic)
        {
            _myLogic = myLogic;
        }

        public bool FromAttribute
        {
            get
            {
                return true;
            }
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            throw new NotImplementedException();
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            return Task.FromResult<IValueProvider>(new MyProvider(_myLogic));
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor();
        }
    }
}
