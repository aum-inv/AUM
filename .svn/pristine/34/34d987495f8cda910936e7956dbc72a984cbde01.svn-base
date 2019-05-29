using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OM.Lib.Framework.Base;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace OM.Lib.Framework.Communication
{
    public class TcpServiceHostContext<O, I>
        where O : IWService
        where I : IWService
    {
        ServiceHost host = null;
        NetTcpBinding binding = null;
        ServiceThrottlingBehavior throttling = null;
      //  ReliableSession reliableSession = null;
        public TcpServiceHostContext()
        {            
        }
        public TcpServiceHostContext(NetTcpBinding binding, ServiceThrottlingBehavior throttling)
        {
            this.binding = binding;
            this.binding.Security.Mode = SecurityMode.None;
            this.throttling = throttling;
        }

        public CommunicationState HostState
        {
            get
            {
                return host.State;
            }
        }
        public ServiceHost Host
        {
            get
            {
                return host;
            }
        }
        public void Run(O service, string ip,  int port)
        {
            try
            {
                if (binding == null)
                { 
                    binding = new NetTcpBinding();
                    binding.Security.Mode = SecurityMode.None;
                    binding.OpenTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.ReceiveTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.SendTimeout.Add(new TimeSpan(1, 0, 0));
                    binding.CloseTimeout.Add(new TimeSpan(1, 0, 0));

                    //performance tip
                    binding.ListenBacklog = 1000;
                    binding.TransactionFlow = false;
                    binding.MaxReceivedMessageSize = Int32.MaxValue;
                    binding.MaxBufferSize = Int32.MaxValue;
                    binding.MaxBufferPoolSize = Int32.MaxValue;
                    binding.MaxConnections = 100000;                    
                }
                if (throttling == null)
                {
                    throttling = new ServiceThrottlingBehavior();
                    //performance tip
                    throttling.MaxConcurrentCalls = 10000;
                    throttling.MaxConcurrentInstances = 10000;
                    throttling.MaxConcurrentSessions = 10000;
                }
               
                Uri uri = new Uri(string.Format("net.tcp://{0}:{1}/{2}", ip, port, service.ServiceName));
                host = new ServiceHost(typeof(O), uri);   
                
                host.AddServiceEndpoint(typeof(I), binding, uri);                
                host.Description.Behaviors.Add(throttling);
                
                host.Open();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            try
            {
                if (host == null) return;
                if (host.State == CommunicationState.Opened)
                    host.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
