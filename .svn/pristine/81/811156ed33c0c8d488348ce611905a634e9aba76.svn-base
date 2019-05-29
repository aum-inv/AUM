using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OM.Lib.Framework.Base;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace OM.Lib.Framework.Communication
{
    public class NamedPipeServiceHostClient<T>
        where T : IWService        
    {
        string serviceName = string.Empty;
        NetNamedPipeBinding binding;

        public NamedPipeServiceHostClient(string serviceName)
            : this(serviceName, null)
        {
        }
        public NamedPipeServiceHostClient(string serviceName, NetNamedPipeBinding binding)
        {
            this.serviceName = serviceName;
            this.binding = binding;
        }

        public T Connect(string host)
        {
            try
            {
                string url = string.Format("net.pipe://{0}/{1}", host, serviceName);

                if (binding == null)
                {
                    binding = new NetNamedPipeBinding();
                }

                Uri uri = new Uri(url);
                ServiceEndpoint endPoint = new ServiceEndpoint(
                    ContractDescription.GetContract(typeof(T))
                 , binding
                 , new EndpointAddress(uri));

                ChannelFactory<T> factory = new ChannelFactory<T>(endPoint);

                return factory.CreateChannel();
            }
            catch (System.Exception ex)
            {
                return default(T);
                throw ex;
            }
        }
        public T Connect()
        {
            return Connect("localhost");
        }
    }
}
