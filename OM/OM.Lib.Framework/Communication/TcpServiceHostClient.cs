using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OM.Lib.Framework.Base;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace OM.Lib.Framework.Communication
{
    public class TcpServiceHostClient<T>
        where T : IWService        
    {
        string serviceName = string.Empty;
        NetTcpBinding binding;
        public TcpServiceHostClient(string serviceName)
            : this(serviceName, null)
        {
        }
        public TcpServiceHostClient(string serviceName, NetTcpBinding binding)
        {
            this.serviceName = serviceName;
            this.binding = binding;
            if (this.binding != null)
                this.binding.Security.Mode = SecurityMode.None;
        }
        public T Connect(string host, int port)
        {
            try
            {
                string url = string.Format("net.tcp://{0}:{1}/{2}", host, port, serviceName);

                if (binding == null)
                {
                    binding = new NetTcpBinding();
                    binding.Security.Mode = SecurityMode.None;
                    binding.OpenTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.ReceiveTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.SendTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.CloseTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.TransactionFlow = false;
                    binding.ListenBacklog = 10;
                    binding.MaxReceivedMessageSize = Int32.MaxValue;
                    binding.MaxBufferSize = Int32.MaxValue;                    
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
        public (T service, ChannelFactory<T> channel) ConnectAndFactory(string host, int port)
        {
            try
            {
                string url = string.Format("net.tcp://{0}:{1}/{2}", host, port, serviceName);

                if (binding == null)
                {
                    binding = new NetTcpBinding();
                    binding.Security.Mode = SecurityMode.None;
                    binding.OpenTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.ReceiveTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.SendTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.CloseTimeout.Add(new TimeSpan(1, 0, 0));
                }

                Uri uri = new Uri(url);
                ServiceEndpoint endPoint = new ServiceEndpoint(
                    ContractDescription.GetContract(typeof(T))
                 , binding
                 , new EndpointAddress(uri));

                ChannelFactory<T> factory = new ChannelFactory<T>(endPoint);
                return (factory.CreateChannel(), factory);
            }
            catch (System.Exception ex)
            {
                return (default(T), null);
                throw ex;
            }
        }
        public T Connect(int port)
        {
            return Connect("localhost", port);
        }
        public NetTcpBinding ClientNetTcpBinding
        {
            get
            {
                return binding;
            }
        }
    }
}
