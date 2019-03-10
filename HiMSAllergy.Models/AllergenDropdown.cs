using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HiMSAllergy.Models
{
    [Serializable]
    public class AllergenDropdown
    {
        [XmlAttribute]
        public int CodeId { get; set; }
        [XmlAttribute]
        public string CodeDesc { get; set; }
        [XmlAttribute]
        public string CodeText { get; set; }
        [XmlAttribute]
        public int TypeId { get; set; }
    }
}
