using OM.Lib.Framework.Communication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra.Ctx
{
    public class XingServerConfigData
    {
        public const string ServiceName = "XingService";
        public static string IP = string.Empty;
        public static int Port = 0;
    }
    public class XingContext
    {
        private static XingContext ppContext = null;
        public static XingContext Instance
        {
            get
            {
                if (ppContext == null)
                    ppContext = new XingContext();
                return ppContext;
            }
        }
        
        private TcpServiceHostContext<XingService, IXingService> serverContext = null;
        private XingService serviceObj = null;

        public TcpServiceHostContext<XingService, IXingService> ServerContext
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
                serverContext = new TcpServiceHostContext<XingService, IXingService>();

                serviceObj = new XingService();

                serverContext.Run(serviceObj, XingServerConfigData.IP, XingServerConfigData.Port);

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
        private TcpServiceHostClient<IXingService> clientContext = null;
        private IXingService clientService = null;
        public IXingService ClientContext
        {
            get
            {
                if (clientContext == null)
                {
                    clientContext = new TcpServiceHostClient<IXingService>(XingServerConfigData.ServiceName);
                    clientService = clientContext.Connect(XingServerConfigData.IP, XingServerConfigData.Port);
                }
                else
                {
                    try
                    {
                        clientService.Noop();
                    }
                    catch (System.ServiceModel.CommunicationException)
                    {
                        clientService = clientContext.Connect(XingServerConfigData.IP, XingServerConfigData.Port);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
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
                clientContext = new TcpServiceHostClient<IXingService>(XingServerConfigData.ServiceName);
                clientService = clientContext.Connect(XingServerConfigData.IP, XingServerConfigData.Port);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        public IXingService GetClientService()
        {
            try
            {
                TcpServiceHostClient<IXingService> clientNew = new TcpServiceHostClient<IXingService>(XingServerConfigData.ServiceName);
                IXingService clientServiceNew = clientNew.Connect(XingServerConfigData.IP, XingServerConfigData.Port);

                return clientServiceNew;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
