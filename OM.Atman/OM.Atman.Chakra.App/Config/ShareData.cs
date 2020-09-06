using OM.Lib.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OM.Atman.Chakra.App.Config
{


    public class ShareData
    {
        private static ShareData instance = new ShareData();
        public static ShareData Instance
        {
            get
            {
                return instance;
            }
        }
        public XmlUtility XmlUtil
        {
            get;
            set;
        } = null;
        public XmlNodeList PlanNodeLlist
        {
            get;
            set;
        } = null;
    }
}
