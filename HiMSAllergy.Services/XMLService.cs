using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace HiMSAllergy.Services
{
    public class XMLWriter<T>
    {
        public static List<T> GetData(string filename)
        {
            string xmlFilePath = string.Format("~/App_Data/{0}", filename);
            string absoluteXmlFilePath = HttpContext.Current.Server.MapPath(xmlFilePath);
            XmlSerializer deserializer = new XmlSerializer(typeof(XmlData<T>));
            using (TextReader textReader = new StreamReader(absoluteXmlFilePath))
            {
                var xmlData = (XmlData<T>)deserializer.Deserialize(textReader);
                return xmlData.Data;
            }
        }

        public static void Save(List<T> items, string filename)
        {
            string xmlFilePath = string.Format("~/App_Data/{0}", filename);
            string absoluteXmlFilePath = HttpContext.Current.Server.MapPath(xmlFilePath);
            XmlSerializer serializer = new XmlSerializer(typeof(XmlData<T>));
            using (TextWriter textWriter = new StreamWriter(absoluteXmlFilePath))
            {
                XmlData<T> data = new XmlData<T>();
                data.Data = items;
                serializer.Serialize(textWriter, data);
            }
        }
    }
}
