using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimchaFund.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SimchaFund.Data;

namespace SimchaFund.Web.Controllers
{
    public class SimchasController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=SimchaFund;Integrated Security=true;";

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            var mgr = new SimchaFundManager(_connectionString);
            var viewModel = new SimchaIndexViewModel
            {
                TotalContributors = mgr.GetContributorCount(),
                Simchas = mgr.GetAllSimchas()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(Simcha simcha)
        {
            var mgr = new SimchaFundManager(_connectionString);
            mgr.AddSimcha(simcha);
            TempData["Message"] = $"New Simcha Created! Id: {simcha.Id}";
            return RedirectToAction("index");
        }

        public IActionResult Contributions(int simchaId)
        {
            var mgr = new SimchaFundManager(_connectionString);
            var simcha = mgr.GetSimchaById(simchaId);
            var contributors = mgr.GetSimchaContributorsOneQuery(simchaId);

            var viewModel = new ContributionsViewModel
            {
                Contributors = contributors,
                Simcha = simcha
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateContributions(List<ContributionInclusion> contributors, int simchaId)
        {
            var mgr = new SimchaFundManager(_connectionString);
            mgr.UpdateSimchaContributions(simchaId, contributors);
            TempData["Message"] = "Simcha updated successfully";
            return RedirectToAction("Index");
        }
    }
}
