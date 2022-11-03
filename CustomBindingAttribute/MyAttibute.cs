using Microsoft.Azure.WebJobs.Description;
using System;

namespace TrackPoc.CustomBindingAttribute
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class MyAttribute : Attribute
    {
    }
}
