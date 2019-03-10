using HiMSAllergy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiMSAllergy.Services
{
    public class AllergyService
    {

        public static IEnumerable<Allergy> GetAll()
        {
            var reactions = XMLWriter<Reaction>.GetData("AllergenReactionDropdown.xml");
            var severities = XMLWriter<Severity>.GetData("AllergenSeverityDropdown.xml");
            var items = XMLWriter<Allergy>.GetData("HistoryData.xml").Select(x =>
            {
                x.Reaction = reactions.Where(r => r.CodeId == x.ReactionId).Any() ? reactions.Where(r => r.CodeId == x.ReactionId).First().CodeDesc : "N/A";
                x.Severity = severities.Where(r => r.CodeId == x.SeverityId).Any() ? severities.Where(r => r.CodeId == x.SeverityId).First().CodeDesc : "N/A";
                return x;
            });
            return items;
        }

        public static bool Save(List<Allergy> items)
        {
            XMLWriter<Allergy>.Save(items, "HistoryData.xml");
            return true;
        }
    }
}
