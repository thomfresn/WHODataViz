using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using WHODataViz.ASP.NET.Models;
using WHODataViz.DataModel;

namespace WHODataViz.ASP.NET.Controllers
{
    public class IndicatorDataController : Controller
    {
        private readonly IIndicatorDataFetcher indicatorDataFetcher;
        private readonly IIndicatorsService indicatorsService;

        public IndicatorDataController(IIndicatorsService indicatorsService, IIndicatorDataFetcher indicatorDataFetcher)
        {
            this.indicatorsService = indicatorsService;
            this.indicatorDataFetcher = indicatorDataFetcher;
        }

        [AsyncTimeout(4000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "Timeout")]
        public async Task<ActionResult> Index(string code, CancellationToken ctk)
        {
            IList<Indicator> indicators = await indicatorsService.GetAllIndicatorsAsync();
            Indicator indicator = indicators.FirstOrDefault(x => x.Code == code);
            IndicatorDataItems whoStatistics = await indicatorDataFetcher.GetWHOStatistics(indicator);
            return View(whoStatistics);
        }

        [HttpGet]
        public ActionResult Create(string code)
        {
            CreateIndicatorDataItemViewModel viewModel = new CreateIndicatorDataItemViewModel
            {
                IndicatorCode = code
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateIndicatorDataItemViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Debug.WriteLine($"Create item for {viewModel.IndicatorDescription} : {viewModel.Country} {viewModel.Region} {viewModel.Sex} {viewModel.Year} {viewModel.Value}");
                return RedirectToAction("Index", "IndicatorData", new {code= viewModel.IndicatorCode});
            }
            return View(viewModel);
        }

        


    }
}