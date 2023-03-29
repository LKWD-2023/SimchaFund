using System.Collections.Generic;

namespace SimchaFund.Web.Models
{
    public class HistoryViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public decimal ContributorBalance { get; set; }
        public string ContributorName { get; set; }
    }
}