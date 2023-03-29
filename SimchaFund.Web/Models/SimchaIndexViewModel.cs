using System.Collections.Generic;
using SimchaFund.Data;

namespace SimchaFund.Web.Models
{
    public class SimchaIndexViewModel
    {
        public int TotalContributors { get; set; }
        public List<Simcha> Simchas { get; set; }
    }
}