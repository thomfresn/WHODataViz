using System.Collections.Generic;
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
        public async Task<ActionResult> Index()
        {
            IList<Indicator> indicators = await indicatorsService.GetAllIndicatorsAsync();
            return View(indicators);
        }

        public async Task<ActionResult> IndicatorData(string code)
        {
            IList<WHOStatistics> whoStatistics = await indicatorDataFetcher.GetWHOStatistics(code);
            return View(whoStatistics);
        }


    }
}