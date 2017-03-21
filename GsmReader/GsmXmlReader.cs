using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace GsmReader
{
    class GsmXmlReader
    {
        public XmlDocument xmlDoc;
        public XmlNodeList parametersList;
        public IDictionary<string, GsmXmlParameter> xml_parameters = new Dictionary<string, GsmXmlParameter>();
        public IDictionary<string, int> added_parameters = new Dictionary<string, int>();
        public string script3dText;
        public string filePath = @"C:\Users\Bogdan\Desktop\test.xml";
        public GsmXmlReader(string fileName)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            filePath = fileName;


        }
        public GsmXmlReader get3dScript()
        {
            XmlNode Script3dNode = xmlDoc.SelectSingleNode("/Symbol/Script_3D");
            script3dText = Script3dNode.InnerText;
            return this;
        }
        public GsmXmlReader set3dScript(string text)
        {
            XmlNode Script3dNode = xmlDoc.SelectSingleNode("/Symbol/Script_3D");
            XmlCDataSection CData = xmlDoc.CreateCDataSection(text);
            Script3dNode.InnerText = "";
            Script3dNode.AppendChild(CData);
            return this;
        }

        public GsmXmlReader setInterface(string text)
        {
            XmlNode ScriptUINode = xmlDoc.SelectSingleNode("/Symbol/Script_UI");
            XmlCDataSection CData = xmlDoc.CreateCDataSection(text);
            ScriptUINode.InnerText = "";
            ScriptUINode.AppendChild(CData);
            return this;
        }

        public GsmXmlReader getParameters()
        {
            XmlNode Parameters = xmlDoc.SelectSingleNode("/Symbol/ParamSection/Parameters");
            parametersList = Parameters.ChildNodes;
            XmlNode PreviousNode = null;
            foreach (XmlNode parameter in parametersList)
            {
                if (parameter != null && parameter.Name != "#comment")
                {

                    XmlAttribute param_name = parameter.Attributes["Name"];
                    string p_name = param_name.Value;
                    string p_type = parameter.Name;
                    string p_label = getParamLabelFromXml(parameter);
                    XmlNode ParameterValue = parameter.LastChild;
                    string p_value = ParameterValue.InnerText.Replace('"', ' ').Trim();
                    string p_inner_xml = parameter.InnerXml.ToString();
                    var parameterContainer = new GsmXmlParameter(p_name,p_type,p_label,p_value, p_inner_xml);
                    if (PreviousNode != null)
                    {
                        parameterContainer.setXmlPosition(PreviousNode);
                    }
                    xml_parameters[param_name.Value] = parameterContainer;
                    PreviousNode = parameter;
                }

            }
            return this;
        }
        public GsmXmlReader insertParameter(GsmXmlParameter parameter)
        {
            if (parameter.prev_xml_node != null) { 
            XmlElement xmlElement = xmlDoc.CreateElement(parameter.parameter_type);
            xmlElement.SetAttribute("Name", parameter.parameter_name);
            xmlElement.InnerXml = parameter.inner_xml;
             XmlNode Parameters = xmlDoc.SelectSingleNode("/Symbol/ParamSection/Parameters");
                if (!added_parameters.ContainsKey(parameter.parameter_name))
                {
                    Parameters.InsertAfter(xmlElement, parameter.prev_xml_node);
                    added_parameters[parameter.parameter_name] = 1;
                    MessageBox.Show("Added " + parameter.parameter_name);
                }
            }
            return this;
        }
        public GsmXmlReader insertParameter2(GsmXmlParameter parameter)
        {
            if (parameter.prev_xml_node != null)
            {
                XmlElement xmlElement = xmlDoc.CreateElement(parameter.parameter_type);
                xmlElement.SetAttribute("Name", parameter.parameter_name);
                xmlElement.InnerXml = parameter.inner_xml;
                var ParameterList = xmlElement.ChildNodes;
                //XmlCDataSection CData = xmlDoc.CreateCDataSection(text);
                //Script3dNode.InnerText = "";
                //Script3dNode.AppendChild(CData);
                foreach (XmlNode paramDescrElement in ParameterList)
                {
                    if (paramDescrElement != null && paramDescrElement.Name == "Description")
                    {
                        XmlCDataSection CData = xmlDoc.CreateCDataSection("\""+parameter.parameter_label+"\"");
                        paramDescrElement.InnerText="";
                        paramDescrElement.AppendChild(CData);
                    }
                    if (paramDescrElement != null && paramDescrElement.Name == "Value")
                    {
                        paramDescrElement.InnerText = parameter.parameter_value;
                    }
                }

                XmlNode Parameters = xmlDoc.SelectSingleNode("/Symbol/ParamSection/Parameters");
                if (!added_parameters.ContainsKey(parameter.parameter_name))
                {
                    Parameters.InsertAfter(xmlElement, parameter.prev_xml_node);
                    added_parameters[parameter.parameter_name] = 1;
                    MessageBox.Show("Added " + parameter.parameter_name);
                }
            }
            return this;
        }
        public XmlNode getSimilarParameterXmlNode(XmlNode prev_xml_node)
        {
            foreach (XmlNode parameter in parametersList)
            {
                if (parameter != null && parameter.Name != "#comment")
                {

 
                    string p_inner_xml = parameter.InnerXml.ToString();
                    string param_name = parameter.Attributes["Name"].Value;
                    string prev_param_name = "";
                    if (prev_xml_node != null && prev_xml_node.Attributes != null)
                    {
                        prev_param_name = prev_xml_node.Attributes["Name"].Value;
                    }
                    if (prev_xml_node != null&&prev_xml_node.InnerXml!=null && p_inner_xml == prev_xml_node.InnerXml)
                    {
                        //MessageBox.Show("we found a match");
                        return parameter;
                    }else if (prev_xml_node!=null&& param_name==prev_param_name)
                    {
                        //MessageBox.Show("we found a match");
                        return parameter;
                        
                    }

                }

            }
            return null;
        }
        public string getParamLabelFromXml(XmlNode parameter)
        {
            var AttributesList = parameter.ChildNodes;
            foreach (XmlNode paramDescrElement in AttributesList)
            {
                if (paramDescrElement != null && paramDescrElement.Name == "Description")
                {
                    return paramDescrElement.InnerText.Replace('"', ' ').Trim();
                }
            }
            return "";
        }
        public void saveXml(string filePath)
        {
            xmlDoc.Save(filePath);
        }
    }
    class GsmXmlParameter
    {
        public string parameter_name;
        public string parameter_type;
        public string parameter_label;
        public string parameter_value;
        public string inner_xml;
        public XmlNode prev_xml_node;
        public GsmXmlParameter(string name,string type,string label,string value,string inner_xml_val)
        {
            parameter_name = name;
            parameter_type = type;
            parameter_label = label;
            parameter_value = value;
            inner_xml = inner_xml_val;
        }
        public GsmXmlParameter setXmlPosition(XmlNode xml_node)
        {
            prev_xml_node = xml_node;
            return this;
        }
    }
}
