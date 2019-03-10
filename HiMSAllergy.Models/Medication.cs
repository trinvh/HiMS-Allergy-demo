using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HiMSAllergy.Models
{
    [Serializable]
    public class Medication
    {
        [XmlAttribute]
        public int DrugId { get; set; }
        [XmlAttribute]
        public string DrugName { get; set; }
        [XmlAttribute]
        public string LexiDrugId { get; set; }
    }
}
