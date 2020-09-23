using OM.Lib.Framework.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Chakra.Daemon
{
    public class VikalaServerConfigData
    {
        public const string ServiceName = "VikalaService";
        public static string IP = string.Empty;
        public static int Port = 0;
    }
    public class VikalaContext
    {
        private static VikalaContext ppContext = null;
        public static VikalaContext Instance
        {
            get
            {
                if (ppContext == null)
                    ppContext = new VikalaContext();
                return ppContext;
            }
        }
        
        private TcpServiceHostContext<VikalaService, IVikalaService> serverContext = null;
        private VikalaService serviceObj = null;

        public TcpServiceHostContext<VikalaService, IVikalaService> ServerContext
        {
            get
            {
                return serverContext;
            }
        }

        public void StartServer()
        {
            try
            {
                serverContext = new TcpServiceHostContext<VikalaService, IVikalaService>();

                serviceObj = new VikalaService();

                serverContext.Run(serviceObj, VikalaServerConfigData.IP, VikalaServerConfigData.Port);

                serverContext.Host.Faulted += (o, e) => { StartServer(); };

            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
        public void CloseServer()
        {
            try
            {
                serverContext.Close();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        /// 
        private TcpServiceHostClient<IVikalaService> clientContext = null;
        private IVikalaService clientService = null;
        public IVikalaService ClientContext
        {
            get
            {
                if (clientContext == null)
                {
                    clientContext = new TcpServiceHostClient<IVikalaService>(VikalaServerConfigData.ServiceName);
                    clientService = clientContext.Connect(VikalaServerConfigData.IP, VikalaServerConfigData.Port);
                }
                else
                {
                    try
                    {
                        clientService.Noop();
                    }
                    catch (System.ServiceModel.CommunicationException)
                    {
                        clientService = clientContext.Connect(VikalaServerConfigData.IP, VikalaServerConfigData.Port);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }

                return clientService;

                //return GetClientService();
            }
        }

        public void OnCreateClient()
        {
            try
            {
                clientContext = new TcpServiceHostClient<IVikalaService>(VikalaServerConfigData.ServiceName);
                clientService = clientContext.Connect(VikalaServerConfigData.IP, VikalaServerConfigData.Port);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        public IVikalaService GetClientService()
        {
            try
            {
                TcpServiceHostClient<IVikalaService> clientNew = new TcpServiceHostClient<IVikalaService>(VikalaServerConfigData.ServiceName);
                IVikalaService clientServiceNew = clientNew.Connect(VikalaServerConfigData.IP, VikalaServerConfigData.Port);

                return clientServiceNew;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
