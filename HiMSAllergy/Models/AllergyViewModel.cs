using HiMSAllergy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiMSAllergy.Models
{
    public class AllergyViewModel
    {
        private List<AllergenType> _allergenTypes;
        private List<Allergen> _allergens;
        private List<Severity> _severities;
        private List<Reaction> _reactions;

        public IEnumerable<SelectListItem> DefaultListItems
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Please select an option"
                }, count: 1);
            }
        }
        public Allergy Allergy { get; set; }

        public IEnumerable<SelectListItem> AllegenTypes {
            get {
                return DefaultListItems.Concat(_allergenTypes.Select(x => new SelectListItem
                {
                    Value = x.CodeId.ToString(),
                    Text = x.CodeText
                }));
            }
        }

        public IEnumerable<SelectListItem> Allergens
        {
            get
            {
                return DefaultListItems.Concat(_allergens.Select(x => new SelectListItem
                {
                    Value = x.CodeId.ToString(),
                    Text = x.CodeText
                }));
            }
        }

        public IEnumerable<SelectListItem> Severities
        {
            get
            {
                return DefaultListItems.Concat(_severities.Select(x => new SelectListItem
                {
                    Value = x.CodeId.ToString(),
                    Text = x.CodeDesc
                }));
            }
        }

        public IEnumerable<SelectListItem> Reactions
        {
            get
            {
                return DefaultListItems.Concat(_reactions.Select(x => new SelectListItem
                {
                    Value = x.CodeId.ToString(),
                    Text = x.CodeDesc
                }));
            }
        }

        public AllergyViewModel()
        {
            this._allergenTypes = XMLWriter<AllergenType>.GetData("AllergenTypeDropdown.xml");
            this._allergens = XMLWriter<Allergen>.GetData("AllergenDropdown.xml");
            this._severities = XMLWriter<Severity>.GetData("AllergenSeverityDropdown.xml");
            this._reactions = XMLWriter<Reaction>.GetData("AllergenReactionDropdown.xml");
            this.Allergy = new Allergy();
        }
    }
}