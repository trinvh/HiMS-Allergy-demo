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
    public class MedicationsController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var items = XMLWriter<Medication>.GetData("MedicationDropdown.xml");
            return Json(new
            {
                success = true,
                data = items
            });
        }

    }
}