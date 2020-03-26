using OM.Lib.Framework.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra.Ctx
{
    public class AtmanServerConfigData
    {
        public const string ServiceName = "AtmanService";
        public static string IP = string.Empty;
        public static int Port = 0;
    }
    public class AtmanContext
    {
        private static AtmanContext ppContext = null;
        public static AtmanContext Instance
        {
            get
            {
                if (ppContext == null)
                    ppContext = new AtmanContext();
                return ppContext;
            }
        }
        
        private TcpServiceHostContext<AtmanService, IAtmanService> serverContext = null;
        private AtmanService serviceObj = null;

        public TcpServiceHostContext<AtmanService, IAtmanService> ServerContext
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
                serverContext = new TcpServiceHostContext<AtmanService, IAtmanService>();

                serviceObj = new AtmanService();

                serverContext.Run(serviceObj, AtmanServerConfigData.IP, AtmanServerConfigData.Port);

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
        private TcpServiceHostClient<IAtmanService> clientContext = null;
        private IAtmanService clientService = null;
        public IAtmanService ClientContext
        {
            get
            {
                if (clientContext == null)
                {
                    clientContext = new TcpServiceHostClient<IAtmanService>(AtmanServerConfigData.ServiceName);
                    clientService = clientContext.Connect(AtmanServerConfigData.IP, AtmanServerConfigData.Port);
                }
                else
                {
                    try
                    {
                        clientService.Noop();
                    }
                    catch (System.ServiceModel.CommunicationException)
                    {
                        clientService = clientContext.Connect(AtmanServerConfigData.IP, AtmanServerConfigData.Port);
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
                clientContext = new TcpServiceHostClient<IAtmanService>(AtmanServerConfigData.ServiceName);
                clientService = clientContext.Connect(AtmanServerConfigData.IP, AtmanServerConfigData.Port);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        public IAtmanService GetClientService()
        {
            try
            {
                TcpServiceHostClient<IAtmanService> clientNew = new TcpServiceHostClient<IAtmanService>(AtmanServerConfigData.ServiceName);
                IAtmanService clientServiceNew = clientNew.Connect(AtmanServerConfigData.IP, AtmanServerConfigData.Port);

                return clientServiceNew;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
