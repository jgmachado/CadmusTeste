using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;

namespace Cadmus.Entities.Config
{
    /// <summary>
    /// Classe para instanciar o WCF
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseWebServicePlatform<T>
    {
        protected ChannelFactory<T> factory;
        protected T wcf;

        private BasicHttpBinding GetDefaultBinding()
        {
            var binding = new BasicHttpBinding();

            binding.CloseTimeout = new TimeSpan(0, 1, 0);
            binding.OpenTimeout = new TimeSpan(0, 1, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 1, 0);
            binding.SendTimeout = new TimeSpan(0, 1, 0);
            binding.AllowCookies = false;
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.MaxBufferSize = 1000000;
            binding.MaxBufferPoolSize = 1000000;
            binding.MaxReceivedMessageSize = 1000000;
            binding.MessageEncoding = WSMessageEncoding.Text;
            binding.TextEncoding = Encoding.UTF8;
            binding.TransferMode = TransferMode.Buffered;
            binding.UseDefaultWebProxy = true;
            binding.Security.Mode = BasicHttpSecurityMode.None;
            binding.ReaderQuotas.MaxDepth = 2147483647;
            binding.ReaderQuotas.MaxStringContentLength = 2147483647;
            binding.ReaderQuotas.MaxArrayLength = 2147483647;
            binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
            binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

            return binding;
        }

        protected BaseWebServicePlatform(string webserviceUrl)
        {
            factory = new ChannelFactory<T>(GetDefaultBinding(), new EndpointAddress(webserviceUrl));
            wcf = factory.CreateChannel();
        }

        protected BaseWebServicePlatform(string webserviceUrl, Binding customBinding)
        {
            factory = new ChannelFactory<T>(customBinding, new EndpointAddress(webserviceUrl));
            wcf = factory.CreateChannel();
        }
    }
}
