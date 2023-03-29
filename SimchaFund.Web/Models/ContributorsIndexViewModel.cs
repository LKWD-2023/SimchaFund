using System.Collections.Generic;
using SimchaFund.Data;

namespace SimchaFund.Web.Models
{
    public class ContributorsIndexViewModel
    {
        public List<Contributor> Contributors { get; set; }
        public decimal Total { get; set; }
    }
}