using OM.Lib.Framework.Communication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra.Ctx
{
    public class PPServerConfigData
    {
        public const string ServiceName = "PPService";
        public static string IP = string.Empty;
        public static int Port = 0;
    }
    public class PPContext
    {
        private static PPContext ppContext = null;
        public static PPContext Instance
        {
            get
            {
                if (ppContext == null)
                    ppContext = new PPContext();
                return ppContext;
            }
        }
        
        private TcpServiceHostContext<PPService, IPPService> serverContext = null;
        private PPService serviceObj = null;

        public TcpServiceHostContext<PPService, IPPService> ServerContext
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
                serverContext = new TcpServiceHostContext<PPService, IPPService>();

                serviceObj = new PPService();

                serverContext.Run(serviceObj, PPServerConfigData.IP, PPServerConfigData.Port);

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
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        /// 
        private TcpServiceHostClient<IPPService> clientContext = null;
        private IPPService clientService = null;
        public IPPService ClientContext
        {
            get
            {
                if (clientContext == null)
                {
                    clientContext = new TcpServiceHostClient<IPPService>(PPServerConfigData.ServiceName);
                    clientService = clientContext.Connect(PPServerConfigData.IP, PPServerConfigData.Port);
                }
                else
                {
                    try
                    {
                        clientService.Noop();
                    }
                    catch (System.ServiceModel.CommunicationException)
                    {
                        clientService = clientContext.Connect(PPServerConfigData.IP, PPServerConfigData.Port);
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
                clientContext = new TcpServiceHostClient<IPPService>(PPServerConfigData.ServiceName);
                clientService = clientContext.Connect(PPServerConfigData.IP, PPServerConfigData.Port);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        public IPPService GetClientService()
        {
            try
            {
                TcpServiceHostClient<IPPService> clientNew = new TcpServiceHostClient<IPPService>(PPServerConfigData.ServiceName);
                IPPService clientServiceNew = clientNew.Connect(PPServerConfigData.IP, PPServerConfigData.Port);

                return clientServiceNew;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
