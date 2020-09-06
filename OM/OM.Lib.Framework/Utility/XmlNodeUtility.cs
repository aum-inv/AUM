using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OM.Lib.Framework.Utility
{
    public class XmlNodeUtility
    {
        string filename = string.Empty;
        XmlNode xmlNode = null;

        /// <summary>
        /// 현재 메모리에 있는 XMLCODUMENT 
        /// </summary>
        public XmlNode XDocument
        {
            get
            {
                return xmlNode;
            }
            set
            {
                xmlNode = value;
            }
        }

        public string Xml
        {
            get
            {
                if (xmlNode != null)
                    return xmlNode.OuterXml;
                else
                    return string.Empty;
            }
        }

        #region 생성자
       
        public XmlNodeUtility(XmlNode xmlNode)
        {
            this.xmlNode = xmlNode;
        }

        #endregion
               
        #region SetElementValue
        /// <summary>
        /// 요소 이름에 해당하는 값을 찾아서 첫번째로 찾아진 요소의 값을 변경한다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="elementValue">요소 값</param>
        public void SetElementValue(string elementName, string elementValue)
        {
            if (xmlNode == null) return;

            XmlNode node = xmlNode.SelectSingleNode("//" + elementName);

            if (node != null)
            {
                node.InnerText = elementValue;
            }
        }
        public void SetElementValue(string elementName, string elementValue, params string[] elementPath)
        {
            if (xmlNode == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNode node = xmlNode.SelectSingleNode($".{path}/{elementName}");

            if (node != null)
            {
                node.InnerText = elementValue;
            }
        }

        /// <summary>
        /// 요소 이름에 해당하는 값을 찾아서 해당 인덱스의 위치에 찾아진 요소의 값을 변경한다.
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">요소 이름</param>
        /// <param name="elementValue">요소 값</param>
        public void SetElementValue(int index, string elementName, string elementValue)
        {
            if (xmlNode == null) return;

            XmlNodeList nodeList = xmlNode.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                nodeList[index].InnerText = elementValue;
            }
        }
        public void SetElementValue(int index, string elementName, string elementValue, params string[] elementPath)
        {
            if (xmlNode == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlNode.SelectNodes($".{path}/{elementName}");

            if (nodeList != null && nodeList[index] != null)
            {
                nodeList[index].InnerText = elementValue;
            }
        }
        #endregion

        #region SetElementAttributeValue

        /// <summary>
        /// 속성값을 변경한다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public void SetElementAttributeValue(string elementName, string attributeName, string attributeValue)
        {
            if (xmlNode == null) return;

            XmlNode node = xmlNode.SelectSingleNode("//" + elementName);

            if (node != null && node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].InnerText = attributeValue;
            }
        }
        public void SetElementAttributeValue(string elementName, string attributeName, string attributeValue, params string[] elementPath)
        {
            if (xmlNode == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNode node = xmlNode.SelectSingleNode($".{path}/{elementName}");

            if (node != null && node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].InnerText = attributeValue;
            }
        }

        /// <summary>
        /// 속성값을 변경한다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public void SetElementAttributeValue(string elementName, string attributeName, string attributeValue, string attributeName2, string attributeValue2)
        {
            if (xmlNode == null) return;

            XmlNode node = xmlNode.SelectSingleNode(string.Format("//{0}[@{1}='{2}']", elementName, attributeName, attributeValue));

            if (node != null && node.Attributes[attributeName2] != null)
            {
                node.Attributes[attributeName2].InnerText = attributeValue2;
            }
        }

        /// <summary>
        /// 속성값을 변경한다.
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public void SetElementAttributeValue(int index, string elementName, string attributeName, string attributeValue)
        {
            if (xmlNode == null) return;

            XmlNodeList nodeList = xmlNode.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                nodeList[index].Attributes[attributeName].InnerText = attributeValue;
            }
        }
        public void SetElementAttributeValue(int index, string elementName, string attributeName, string attributeValue, params string[] elementPath)
        {
            if (xmlNode == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlNode.SelectNodes($".{path}/{elementName}");

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                nodeList[index].Attributes[attributeName].InnerText = attributeValue;
            }
        }

        #endregion

        #region GetElementValue
        public XmlNode GetElement(string elementName)
        {
            if (xmlNode == null) return null;

            XmlNode node = xmlNode.SelectSingleNode("//" + elementName);
            return node;
        }

        public XmlNode GetElement(int index, string elementName)
        {
            if (xmlNode == null) return null;

            XmlNodeList nodeList = xmlNode.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                return nodeList[index];
            }
            return null;
        }

        public XmlNodeList GetElements(string elementName)
        {
            if (xmlNode == null) return null;

            XmlNodeList nodes = xmlNode.SelectNodes("//" + elementName);
            return nodes;
        }

        /// <summary>
        /// 속성값을 리턴합니다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public XmlNodeList GetElements(string elementName, string attributeName, string attributeVal)
        {
            if (xmlNode == null) return null;

            XmlNode node = xmlNode.SelectSingleNode(string.Format("//{0}[@{1}='{2}']", elementName, attributeName, attributeVal));

            if (node == null)
                return null;
            else
                return node.ChildNodes;
        }
        #endregion

        /// <summary>
        /// 요소 이름에 해당하는 값을 찾아서 해당 인덱스의 위치에 찾아진 요소의 값을 리턴합니다.
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">요소 이름</param>
        /// <param name="elementValue">요소 값</param>
        public string GetElementValue(int index, string elementName)
        {
            if (xmlNode == null) return null;

            XmlNodeList nodeList = xmlNode.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                return nodeList[index].InnerText;
            }
            return null;
        }


        public string GetElementValue(string elementName, params string[] elementPath)
        {
            try
            {
                if (xmlNode == null) return string.Empty;

                string path = "";
                foreach (var p in elementPath)
                    path += $"/{p}";

                XmlNode node = xmlNode.SelectSingleNode($".{path}/{elementName}");

                if (node != null)
                {
                    return node.InnerText;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        public string GetElementValue(int index, string elementName, params string[] elementPath)
        {
            if (xmlNode == null) return null;

            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlNode.SelectNodes($".{path}/{elementName}");

            if (nodeList != null && nodeList[index] != null)
            {
                return nodeList[index].InnerText;
            }
            return null;
        }
   
        #region GetElementAttributeValue

        /// <summary>
        /// 속성값을 리턴합니다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public string GetElementAttributeValue(string elementName, string attributeName)
        {
            if (xmlNode == null) return null;

            XmlNode node = xmlNode.SelectSingleNode("//" + elementName);

            if (node != null && node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].InnerText;
            }
            return null;
        }
        public string GetElementAttributeValue(string elementName, string attributeName, params string[] elementPath)
        {
            if (xmlNode == null) return null;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNode node = xmlNode.SelectSingleNode($".{path}/{elementName}");

            if (node != null && node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].InnerText;
            }
            return null;
        }


        /// <summary>
        /// 속성값을 리턴합니다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public string GetElementAttributeValue(string elementName, string attributeName, string attributeVal, string attributeName2)
        {
            if (xmlNode == null) return null;

            XmlNode node = xmlNode.SelectSingleNode(string.Format("//{0}[@{1}='{2}']", elementName, attributeName, attributeVal));

            if (node != null && node.Attributes[attributeName2] != null)
            {
                return node.Attributes[attributeName2].InnerText;
            }

            if (elementName.Equals("property"))
                return "N/A";

            return string.Empty;
        }

        /// <summary>
        /// 속성값을 리턴합니다.
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public string GetElementAttributeValue(int index, string elementName, string attributeName)
        {
            if (xmlNode == null) return null;

            XmlNodeList nodeList = xmlNode.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                return nodeList[index].Attributes[attributeName].InnerText;
            }
            return null;
        }
        public string GetElementAttributeValue(int index, string elementName, string attributeName, params string[] elementPath)
        {
            if (xmlNode == null) return null;

            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlNode.SelectNodes($".{path}/{elementName}");

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                return nodeList[index].Attributes[attributeName].InnerText;
            }
            return null;
        }

        public string GetElementAttributeValue(System.Xml.XmlNode node, string attributeName)
        {
            if (xmlNode == null) return null;

            if (node != null && node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].InnerText;
            }
            return null;
        }
        #endregion

        #region GetElementCount
        public int GetElementCount(string elementName)
        {
            if (xmlNode == null) return 0;

            XmlNodeList nodeList = xmlNode.SelectNodes("//" + elementName);

            if (nodeList != null)
                return nodeList.Count;

            return 0;
        }
        #endregion          
    }
}
