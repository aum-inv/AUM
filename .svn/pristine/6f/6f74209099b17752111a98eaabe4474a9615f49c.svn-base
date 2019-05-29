using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using OM.Lib.Framework.Base;

namespace OM.Lib.Framework.Communication
{
    public class NamedPipeServiceHostContext<O, I>
        where O : IWService
        where I : IWService
    {
        ServiceHost host = null;
        NetNamedPipeBinding binding;
        ServiceThrottlingBehavior throttling;
                
        public NamedPipeServiceHostContext()
        {            
        }
        public NamedPipeServiceHostContext(NetNamedPipeBinding binding, ServiceThrottlingBehavior throttling)
        {
            this.binding = binding;
            this.throttling = throttling;
        }

        public void Run(O service)
        {
            try
            {
                if (binding == null)
                {
                    binding = new NetNamedPipeBinding();                    
                }
                if (throttling == null)
                {
                    throttling = new ServiceThrottlingBehavior();
                }

                Uri uri = new Uri(string.Format("net.pipe://{0}/{1}", "localhost", service.ServiceName));
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
