using HiMSAllergy.Models;
using HiMSAllergy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HiMSAllergy.Controllers.Apis
{
    public class ReactionsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var items = XMLWriter<Reaction>.GetData("AllergenReactionDropdown.xml");
            return Json(new
            {
                success = true,
                data = items
            });
        }
    }
}