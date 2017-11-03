using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WHODataViz.DataModel;

namespace WHODataViz.ASP.NET.Controllers
{
    public class IndicatorsController : Controller
    {
        private readonly IIndicatorsService indicatorsService;
        private readonly IIndicatorDataFetcher indicatorDataFetcher;

        public IndicatorsController(IIndicatorsService indicatorsService, IIndicatorDataFetcher indicatorDataFetcher)
        {
            this.indicatorsService = indicatorsService;
            this.indicatorDataFetcher = indicatorDataFetcher;
        }

        // GET: Indicators
        [AsyncTimeout(4000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "Timeout")]
        public async Task<ActionResult> Index(string q)
        {
            IList<Indicator> indicators = await indicatorsService.GetAllIndicatorsAsync();
            return View(indicators.Where(i => string.IsNullOrEmpty(q) || i.Description.Contains(q)));
        }

        


    }
}