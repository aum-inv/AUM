using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OM.Lib.Framework.Base;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace OM.Lib.Framework.Communication
{
    public class ServiceHostClient<T>
        where T : IWService        
    {
        string serviceName = string.Empty;
        BasicHttpBinding binding;
        public ServiceHostClient(string serviceName)
            : this(serviceName, null)
        {            
        }
        public ServiceHostClient(string serviceName, BasicHttpBinding binding)
        {
            this.serviceName = serviceName;
            this.binding = binding;
        }
        public T Connect(string host, int port)
        {
            try
            {
                string url = string.Format("http://{0}:{1}/{2}/", host, port, serviceName);

                if (binding == null)
                {
                    binding = new BasicHttpBinding();
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
        public T Connect(int port)
        {
            return Connect("localhost", port);
        }
        public T Connect()
        {
            return Connect("localhost", 80);
        }
    }
}
