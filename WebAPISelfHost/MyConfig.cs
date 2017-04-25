using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;
using System.ServiceModel;


namespace WebAPISelfHost
{
    public  class MyConfig : HttpSelfHostConfiguration
    {
        private string v;
        protected override System.ServiceModel.Channels.BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {
            httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.
                Security.
                Transport.
                ClientCredentialType = HttpClientCredentialType.Windows;
            return base.OnConfigureBinding(httpBinding);
        }

        public MyConfig(string v) : base(v)
        {
            this.v = v;
        }
    }
}