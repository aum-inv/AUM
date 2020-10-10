using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OM.Lib.Framework.Utility
{
    public class XmlUtility
    {
        string filename = string.Empty;
        XmlDocument xmlDoc = null;

        /// <summary>
        /// 현재 메모리에 있는 XMLCODUMENT 
        /// </summary>
        public XmlDocument XDocument
        {
            get
            {
                return xmlDoc;
            }
            set
            {
                xmlDoc = value;
            }
        }

        public string Xml
        {
            get
            {
                if (xmlDoc != null)
                    return xmlDoc.OuterXml;
                else
                    return string.Empty;
            }
        }

        #region 생성자
        /// <summary>
        /// 디폴트 생성자
        /// </summary>
        public XmlUtility()
        {
            xmlDoc = new System.Xml.XmlDocument();
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="filename">xml파일명</param>
        public XmlUtility(string filename)
        {
            this.filename = filename;

            xmlDoc = new System.Xml.XmlDocument();

            xmlDoc.Load(filename);
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="filename">xml파일명</param>
        public XmlUtility(string filename, string xml)
        {
            try
            {
                this.filename = filename;

                xmlDoc = new System.Xml.XmlDocument();

                xmlDoc.LoadXml(xml);
            }
            catch
            {

            }
        }

        public XmlUtility(System.IO.Stream stream)
        {
            xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(stream);
        }       

        public XmlUtility(XmlNode xmlNode)
        {
            xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xmlNode.OuterXml);
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
            if (xmlDoc == null) return;

            XmlNode node = xmlDoc.SelectSingleNode("//" + elementName);

            if (node != null)
            {
                node.InnerText = elementValue;
            }
        }
        public void SetElementValue(string elementName, string elementValue, params string[] elementPath)
        {
            if (xmlDoc == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNode node = xmlDoc.SelectSingleNode($"{path}/{elementName}");

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
            if (xmlDoc == null) return;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                nodeList[index].InnerText = elementValue;
            }
        }
        public void SetElementValue(int index, string elementName, string elementValue, params string[] elementPath)
        {
            if (xmlDoc == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlDoc.SelectNodes($"{path}/{elementName}");

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
            if (xmlDoc == null) return;

            XmlNode node = xmlDoc.SelectSingleNode("//" + elementName);

            if (node != null && node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].InnerText = attributeValue;
            }
        }
        public void SetElementAttributeValue(string elementName, string attributeName, string attributeValue, params string[] elementPath)
        {
            if (xmlDoc == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNode node = xmlDoc.SelectSingleNode($"{path}/{elementName}");

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
            if (xmlDoc == null) return;

            XmlNode node = xmlDoc.SelectSingleNode(string.Format("//{0}[@{1}='{2}']", elementName, attributeName, attributeValue));

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
            if (xmlDoc == null) return;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                nodeList[index].Attributes[attributeName].InnerText = attributeValue;
            }
        }
        public void SetElementAttributeValue(int index, string elementName, string attributeName, string attributeValue, params string[] elementPath)
        {
            if (xmlDoc == null) return;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlDoc.SelectNodes($"{path}/{elementName}");

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                nodeList[index].Attributes[attributeName].InnerText = attributeValue;
            }
        }

        #endregion

        #region GetElementValue
        public XmlNode GetElement(string elementName)
        {
            if (xmlDoc == null) return null;

            XmlNode node = xmlDoc.SelectSingleNode("//" + elementName);
            return node;
        }

        public XmlNode GetElement(int index, string elementName)
        {
            if (xmlDoc == null) return null;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                return nodeList[index];
            }
            return null;
        }

        public XmlNodeList GetElements(string elementName)
        {
            if (xmlDoc == null) return null;

            XmlNodeList nodes = xmlDoc.SelectNodes("//" + elementName);
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
            if (xmlDoc == null) return null;

            XmlNode node = xmlDoc.SelectSingleNode(string.Format("//{0}[@{1}='{2}']", elementName, attributeName, attributeVal));

            if (node == null)
                return null;
            else
                return node.ChildNodes;
        }
        #endregion

        #region GetElementValue
        /// <summary>
        /// 요소 이름에 해당하는 값을 찾아서 첫번째로 찾아진 요소의 값을 리턴합니다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="elementValue">요소 값</param>
        public string GetElementValue(string elementName)
        {
            return this.GetElementValue(elementName, ReturnType.TEXT);
        }

        /// <summary>
        /// 요소 이름에 해당하는 값을 찾아서 첫번째로 찾아진 요소의 값을 리턴합니다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="returnType">요소 리턴 타입</param>
        /// <returns></returns>
        public string GetElementValue(string elementName, ReturnType returnType)
        {
            try
            {
                if (xmlDoc == null) return string.Empty;

                XmlNode node = xmlDoc.SelectSingleNode("//" + elementName);

                if (node != null)
                {
                    if (returnType == ReturnType.TEXT)
                        return node.InnerText;
                    else if (returnType == ReturnType.XML)
                        return node.InnerXml;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }



        /// <summary>
        /// 요소 이름에 해당하는 값을 찾아서 해당 인덱스의 위치에 찾아진 요소의 값을 리턴합니다.
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">요소 이름</param>
        /// <param name="elementValue">요소 값</param>
        public string GetElementValue(int index, string elementName)
        {
            if (xmlDoc == null) return null;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

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
                if (xmlDoc == null) return string.Empty;

                string path = "";
                foreach (var p in elementPath)
                    path += $"/{p}";

                XmlNode node = xmlDoc.SelectSingleNode($"{path}/{elementName}");

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
            if (xmlDoc == null) return null;

            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlDoc.SelectNodes($"{path}/{elementName}");

            if (nodeList != null && nodeList[index] != null)
            {
                return nodeList[index].InnerText;
            }
            return null;
        }
        #endregion

        #region GetElementAttributeValue

        /// <summary>
        /// 속성값을 리턴합니다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        /// <param name="attributeName">속성명</param>
        /// <param name="attributeValue">속성값</param>
        public string GetElementAttributeValue(string elementName, string attributeName)
        {
            if (xmlDoc == null) return null;

            XmlNode node = xmlDoc.SelectSingleNode("//" + elementName);

            if (node != null && node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].InnerText;
            }
            return null;
        }
        public string GetElementAttributeValue(string elementName, string attributeName, params string[] elementPath)
        {
            if (xmlDoc == null) return null;
            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNode node = xmlDoc.SelectSingleNode($"{path}/{elementName}");

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
            if (xmlDoc == null) return null;

            XmlNode node = xmlDoc.SelectSingleNode(string.Format("//{0}[@{1}='{2}']", elementName, attributeName, attributeVal));

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
            if (xmlDoc == null) return null;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                return nodeList[index].Attributes[attributeName].InnerText;
            }
            return null;
        }
        public string GetElementAttributeValue(int index, string elementName, string attributeName, params string[] elementPath)
        {
            if (xmlDoc == null) return null;

            string path = "";
            foreach (var p in elementPath)
                path += $"/{p}";

            XmlNodeList nodeList = xmlDoc.SelectNodes($"{path}/{elementName}");

            if (nodeList != null && nodeList[index] != null && nodeList[index].Attributes[attributeName] != null)
            {
                return nodeList[index].Attributes[attributeName].InnerText;
            }
            return null;
        }

        public string GetElementAttributeValue(System.Xml.XmlNode node, string attributeName)
        {
            if (xmlDoc == null) return null;

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
            if (xmlDoc == null) return 0;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null)
                return nodeList.Count;

            return 0;
        }
        #endregion

        #region DelElement
        /// <summary>
        /// 해당 요소의 하부요소(속성포함)을 삭제한다.
        /// </summary>
        /// <param name="elementName">요소 이름</param>
        public void DelElement(string elementName)
        {
            if (xmlDoc == null) return;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                    node.RemoveAll();
            }
        }

        /// <summary>
        /// 해당 요소의 하부요소(속성포함)을 삭제한다.
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">요소 이름</param>
        public void DelElement(int index, string elementName)
        {
            if (xmlDoc == null) return;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                nodeList[index].RemoveAll();
            }
        }
        #endregion

        #region CreateElement
        /// <summary>
        /// 요소 추가하기
        /// </summary>
        /// <param name="parentElementName">부모 노드 명</param>
        /// <param name="elementName">추가할 노드명</param>
        /// <returns></returns>
        public XmlNode CreateElement(string parentElementName, string elementName)
        {
            if (xmlDoc == null) return null;

            XmlNode node = xmlDoc.SelectSingleNode("//" + parentElementName);

            if (node != null)
            {
                XmlNode createNode = xmlDoc.CreateElement(elementName);

                node.AppendChild(createNode);

                return createNode;
            }
            return node;
        }

        public XmlNode CreateElement(XmlNode parentNode, string elementName)
        {
            if (xmlDoc == null) return null;

            XmlNode node = parentNode;
            if (node != null)
            {
                XmlNode createNode = xmlDoc.CreateElement(elementName);

                node.AppendChild(createNode);

                return createNode;
            }
            return node;
        }
        #endregion

        #region CreateAttribute
        /// <summary>
        /// 속성 추가하기
        /// </summary>
        /// <param name="element">노드</param>
        /// <param name="attributes">속성명,속성값의 배열</param>
        public void CreateAttribute(XmlNode element, params string[] attributes)
        {
            if (xmlDoc == null) return;

            for (int i = 0; i < attributes.Length; i++)
            {
                XmlAttribute attr = xmlDoc.CreateAttribute(attributes[i]);
                attr.Value = attributes[i++];

                element.Attributes.Append(attr);
            }
        }
        /// <summary>
        /// 속성 추가하기
        /// </summary>
        /// <param name="elementName">노드명</param>
        /// <param name="attributes">속성명, 속성값의 배열</param>
        public void CreateAttribute(string elementName, params string[] attributes)
        {
            if (xmlDoc == null) return;

            XmlNode node = xmlDoc.SelectSingleNode("//" + elementName);

            if (node != null)
            {
                for (int i = 0; i < attributes.Length; i++)
                {
                    XmlAttribute attr = xmlDoc.CreateAttribute(attributes[i]);
                    attr.Value = attributes[i++];

                    node.Attributes.Append(attr);
                }
            }
        }
        /// <summary>
        /// 속성 추가하기
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">노드명</param>
        /// <param name="attributes">속성명, 속성값의 배열</param>
        public void CreateAttribute(int index, string elementName, params string[] attributes)
        {
            if (xmlDoc == null) return;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                for (int i = 0; i < attributes.Length; i++)
                {
                    XmlAttribute attr = xmlDoc.CreateAttribute(attributes[i]);
                    attr.Value = attributes[i++];

                    nodeList[index].Attributes.Append(attr);
                }
            }
        }

        /// <summary>
        /// 속성 추가하기
        /// </summary>
        /// <param name="element">노드</param>
        /// <param name="attributes">속성명, 속성값의 콜렉션</param>
        public void CreateAttribute(XmlNode element, Dictionary<string, string> attributes)
        {
            if (xmlDoc == null) return;

            foreach (KeyValuePair<string, string> kval in attributes)
            {
                XmlAttribute attr = xmlDoc.CreateAttribute(kval.Key);
                attr.Value = kval.Value;

                element.Attributes.Append(attr);
            }
        }
        /// <summary>
        /// 속성 추가하기
        /// </summary>
        /// <param name="elementName">속성명, 속성값의 배열</param>
        /// <param name="attributes">속성명, 속성값의 콜렉션</param>
        public void CreateAttribute(string elementName, Dictionary<string, string> attributes)
        {
            if (xmlDoc == null) return;

            XmlNode node = xmlDoc.SelectSingleNode("//" + elementName);

            if (node != null)
            {
                foreach (KeyValuePair<string, string> kval in attributes)
                {
                    XmlAttribute attr = xmlDoc.CreateAttribute(kval.Key);
                    attr.Value = kval.Value;

                    node.Attributes.Append(attr);
                }
            }
        }
        /// <summary>
        /// 속성 추가하기
        /// </summary>
        /// <param name="index">인덱스</param>
        /// <param name="elementName">노드명</param>
        /// <param name="attributes">속성명, 속성값의 콜렉션</param>
        public void CreateAttribute(int index, string elementName, Dictionary<string, string> attributes)
        {
            if (xmlDoc == null) return;

            XmlNodeList nodeList = xmlDoc.SelectNodes("//" + elementName);

            if (nodeList != null && nodeList[index] != null)
            {
                foreach (KeyValuePair<string, string> kval in attributes)
                {
                    XmlAttribute attr = xmlDoc.CreateAttribute(kval.Key);
                    attr.Value = kval.Value;

                    nodeList[index].Attributes.Append(attr);
                }
            }
        }
        #endregion

        #region InsertElement
        public void InsertElement(string parentElementName, XmlNode node)
        {
            if (xmlDoc == null) return;

            XmlNode pnode = xmlDoc.SelectSingleNode("//" + parentElementName);

            if (pnode != null)
            {
                if (pnode.ChildNodes.Count > 0)
                    pnode.InsertBefore(node, pnode.FirstChild);
                else
                    pnode.AppendChild(node);
            }
            return;
        }
        public void InsertElement(string parentElementName, string elementName, string xmlContent)
        {
            if (xmlDoc == null) return;

            XmlNode pnode = xmlDoc.SelectSingleNode("//" + parentElementName);

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xmlContent);
            //XmlNode newNode = doc.DocumentElement;

            XmlNode newNode = xmlDoc.CreateNode(XmlNodeType.Element, elementName, "");
            newNode.InnerXml = xmlContent;

            if (pnode != null)
            {
                if (pnode.ChildNodes.Count > 0)
                    pnode.InsertBefore(newNode, pnode.FirstChild);
                else
                    pnode.AppendChild(newNode);
            }
            return;
        }
        public void InsertElement2(string parentElementName, string elementName, string xmlContent)
        {
            if (xmlDoc == null) return;

            XmlNode pnode = xmlDoc.SelectSingleNode("//" + parentElementName);
            
            XmlNode newNode = xmlDoc.CreateNode(XmlNodeType.Element, elementName, "");
            newNode.InnerXml = xmlContent;

            if (pnode != null)
            {
                if (pnode.ChildNodes.Count > 0)
                    pnode.InsertBefore(newNode, pnode.FirstChild);
                else
                    pnode.AppendChild(newNode);
            }
            return;
        }

        #endregion
        /// <summary>
        /// 메모리에 있는 XMLDocument 정보를 파일로 저장한다.
        /// </summary>
        public void Save()
        {
            if (xmlDoc == null) return;
            xmlDoc.Save(filename);
        }

        public void Reload()
        {
            xmlDoc.Load(filename);
        }

        public enum ReturnType
        {
            XML,
            TEXT
        }
    }
}
