using OM.Lib.Framework.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Upaya.Chakra.Ctx
{
    public class UpayaServerConfigData
    {
        public const string ServiceName = "UpayaService";
        public static string IP = string.Empty;
        public static int Port = 0;
    }
    public class UpayaContext
    {
        private static UpayaContext ppContext = null;
        public static UpayaContext Instance
        {
            get
            {
                if (ppContext == null)
                    ppContext = new UpayaContext();
                return ppContext;
            }
        }
        
        private TcpServiceHostContext<UpayaService, IUpayaService> serverContext = null;
        private UpayaService serviceObj = null;

        public TcpServiceHostContext<UpayaService, IUpayaService> ServerContext
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
                serverContext = new TcpServiceHostContext<UpayaService, IUpayaService>();

                serviceObj = new UpayaService();

                serverContext.Run(serviceObj, UpayaServerConfigData.IP, UpayaServerConfigData.Port);

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
        private TcpServiceHostClient<IUpayaService> clientContext = null;
        private IUpayaService clientService = null;
        public IUpayaService ClientContext
        {
            get
            {
                if (clientContext == null)
                {
                    clientContext = new TcpServiceHostClient<IUpayaService>(UpayaServerConfigData.ServiceName);
                    clientService = clientContext.Connect(UpayaServerConfigData.IP, UpayaServerConfigData.Port);
                }
                else
                {
                    try
                    {
                        clientService.Noop();
                    }
                    catch (System.ServiceModel.CommunicationException)
                    {
                        clientService = clientContext.Connect(UpayaServerConfigData.IP, UpayaServerConfigData.Port);
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
                clientContext = new TcpServiceHostClient<IUpayaService>(UpayaServerConfigData.ServiceName);
                clientService = clientContext.Connect(UpayaServerConfigData.IP, UpayaServerConfigData.Port);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        public IUpayaService GetClientService()
        {
            try
            {
                TcpServiceHostClient<IUpayaService> clientNew = new TcpServiceHostClient<IUpayaService>(UpayaServerConfigData.ServiceName);
                IUpayaService clientServiceNew = clientNew.Connect(UpayaServerConfigData.IP, UpayaServerConfigData.Port);

                return clientServiceNew;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
