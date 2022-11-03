using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Threading.Tasks;

namespace TrackPoc.CustomBindingAttribute
{
    internal class MyProvider : IValueProvider
    {
        private readonly IMyLogic _myLogic;

        public MyProvider(IMyLogic myLogic)
        {
            _myLogic = myLogic;
        }

        public Type Type
        {
            get
            {
                return typeof(string);
            }
        }

        public Task<object> GetValueAsync()
        {
            _myLogic.Track();
            return Task.FromResult<object>("done");
        }

        public string ToInvokeString()
        {
            return "token";
        }
    }
}