using HiMSAllergy.Models;
using HiMSAllergy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HiMSAllergy.Controllers.Apis
{
    public class AllergiesController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get(string status = "active", string timeScale = "all")
        {
            var items = AllergyService.GetAll();
            items = items.Where(x => string.IsNullOrEmpty(status) || x.Deleted == (status == "active" ? 0 : 1)).ToList();
            if (timeScale == "6months")
            {
                items = items.Where(x => x.UpdateDateWithTime > DateTime.Now.AddMonths(-6)).ToList();
            } else if (timeScale == "recently")
            {
                items = items.Where(x => x.UpdateDateWithTime > DateTime.Now.AddMonths(-1)).ToList();
            }
            return Json(new
            {
                success = true,
                data = items
            });
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]dynamic value)
        {
            var allergenType = XMLWriter<AllergenType>.GetData("AllergenTypeDropdown.xml").Where(x => x.CodeId == (int)value.allergen_type).FirstOrDefault();
            var items = XMLWriter<Allergy>.GetData("HistoryData.xml");

            Allergy item = new Allergy();
            // fake id
            item.ClientAllergyId = (int) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            item.Type = allergenType.CodeText;
            try
            {
                var allergen = XMLWriter<AllergenType>.GetData("AllergenDropdown.xml").Where(x => x.CodeId == (int)value.allergen).FirstOrDefault();
                item.Allergen = allergenType.CodeText == "Allergen" ? allergen.CodeText : null;
            }
            catch { }
            item.AllergenType = value.allergen_type;
            item.DrugName = value.medication;
            item.Notes = value.notes;
            item.ReactionId = value.reaction;
            item.SeverityId = value.severity;
            item.UpdateDate = DateTime.Now.ToString("dd/MM/yyyy");
            item.UpdateDateWithTime = DateTime.Now;
            item.UpdateUser = "InApps";
            item.CreateDate = DateTime.Now.ToString("dd/MM/yyyy");
            item.CreateDateWithTime = DateTime.Now;
            item.CreateUser = "InApps";
            items.Add(item);
            AllergyService.Save(items);
            return Json(new
            {
                success = true,
                message = "Saved successfully"
            });
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]dynamic value)
        {
            var items = XMLWriter<Allergy>.GetData("HistoryData.xml");
            var item = items.Where(x => x.ClientAllergyId == id).FirstOrDefault();
            if (item != null)
            {
                var allergenType = XMLWriter<AllergenType>.GetData("AllergenTypeDropdown.xml").Where(x => x.CodeId == (int) value.allergen_type).FirstOrDefault();
                item.Type = allergenType.CodeText;
                try
                {
                    var allergen = XMLWriter<AllergenType>.GetData("AllergenDropdown.xml").Where(x => x.CodeId == (int)value.allergen).FirstOrDefault();
                    item.Allergen = allergenType.CodeText == "Allergen" ? allergen.CodeText : null;
                }
                catch { }
                item.AllergenType = value.allergen_type;
                item.DrugName = value.medication;
                item.Notes = value.notes;
                item.ReactionId = value.reaction;
                item.SeverityId = value.severity;
                item.UpdateDate = DateTime.Now.ToString("dd/MM/yyyy");
                item.UpdateDateWithTime = DateTime.Now;
                item.UpdateUser = "InApps";
                AllergyService.Save(items);
                return Json(new
                {
                    success = true,
                    message = "Saved successfully"
                });
            } else
            {
                return Json(new
                {
                    success = false,
                    message = "Entity not found"
                });
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var items = XMLWriter<Allergy>.GetData("HistoryData.xml");
            var allergenTypes = XMLWriter<AllergenType>.GetData("AllergenTypeDropdown.xml");
            var item = items.Where(x => x.ClientAllergyId == id).FirstOrDefault();
            if (item != null)
            {
                items.Remove(item);
                AllergyService.Save(items);
                return Json(new
                {
                    success = true
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "Entity not found"
                });
            }
        }

    }
}