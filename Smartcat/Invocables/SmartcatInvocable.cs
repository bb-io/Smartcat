using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Smartcat.API;

namespace Apps.Smartcat.Invocables
{
    public class SmartcatInvocable : BaseInvocable
    {
        protected AuthenticationCredentialsProvider[] Creds =>
            InvocationContext.AuthenticationCredentialsProviders.ToArray();

        protected SmartcatClient Client { get; }

        public SmartcatInvocable(InvocationContext invocationContext) : base(invocationContext)
        {
            Client = new();
        }
    }
}
