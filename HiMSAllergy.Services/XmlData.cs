using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HiMSAllergy.Services
{
    [Serializable]
    [XmlRoot("Data")]
    public class XmlData<T>
    {
        [XmlElement("row")]
        public List<T> Data { get; set; }
    }
}
