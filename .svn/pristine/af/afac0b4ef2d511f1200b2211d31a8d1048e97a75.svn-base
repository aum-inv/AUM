using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OM.Lib.Framework.Base;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace OM.Lib.Framework.Communication
{
    public class ServiceHostContext<O, I> 
        where O : IWService
        where I : IWService
    { 
        ServiceHost host = null;
        BasicHttpBinding binding;
        ServiceThrottlingBehavior throttling;
                
        public ServiceHostContext()
        {            
        }
        public ServiceHostContext(BasicHttpBinding binding, ServiceThrottlingBehavior throttling)
        {
            this.binding = binding;
            this.throttling = throttling;
        }
        public void Run(O service)
        {
            Run(service, 80);
        }
        public void Run(O service, int port)
        {
            try
            {
                if (binding == null)
                {
                    binding = new BasicHttpBinding();
                }
                if (throttling == null)
                {
                    throttling = new ServiceThrottlingBehavior();
                    throttling.MaxConcurrentCalls = 1000;
                    throttling.MaxConcurrentInstances = 1000;
                }

                host = new ServiceHost(typeof(O),
                    new Uri(string.Format("http://{0}:{1}/{2}/", "localhost", port, service.ServiceName)));
                
                host.AddServiceEndpoint(typeof(I), binding, "");

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
                if(host == null) return;
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
