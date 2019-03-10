using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HiMSAllergy.Models
{
    [Serializable]
    [XmlType("row")]
    public class Allergy
    {
        [XmlAttribute]
        public int ClientId { get; set; }
        [XmlAttribute]
        public string ClientName { get; set; }
        [XmlAttribute]
        public string CISId { get; set; }
        [XmlAttribute]
        public string DOB { get; set; }
        [XmlAttribute]
        public string Gender { get; set; }
        [XmlAttribute]
        public string Provider { get; set; }
        [XmlAttribute]
        public string Population { get; set; }
        [XmlAttribute]
        public string AxisI { get; set; }
        [XmlAttribute]
        public string AxisIDesc { get; set; }
        [XmlAttribute]
        public int ClientAllergyId { get; set; }
        [XmlAttribute]
        public string Allergen { get; set; }
        [XmlAttribute]
        public int Deleted { get; set; }
        [XmlAttribute]
        public string Notes { get; set; }
        [XmlAttribute]
        public string CreateUser { get; set; }
        [XmlAttribute]
        public string CreateDate { get; set; }
        [XmlAttribute]
        public string UpdateUser { get; set; }
        [XmlAttribute]
        public string UpdateDate { get; set; }
        [XmlAttribute]
        [Display(Name ="Allergen")]
        public int AllergenId { get; set; }
        [XmlAttribute]
        public int AllergenType { get; set; }
        [XmlAttribute]
        [Display(Name = "Reaction")]
        public int ReactionId { get; set; }
        [XmlAttribute]
        [Display(Name = "Severity")]
        public int SeverityId { get; set; }
        [XmlAttribute]
        public string ReactionDesc { get; set; }
        [XmlAttribute]
        public string SeverityDesc { get; set; }
        [XmlAttribute]
        [Display(Name = "Allergen Type")]
        public string Type { get; set; }
        [XmlAttribute]
        [Display(Name = "Prescription")]
        public string DrugName { get; set; }
        [XmlAttribute]
        public DateTime CreateDateWithTime { get; set; }
        [XmlAttribute]
        public DateTime UpdateDateWithTime { get; set; }

        public string Reaction { get; set; }
        public string Severity { get; set; }

    }
}
