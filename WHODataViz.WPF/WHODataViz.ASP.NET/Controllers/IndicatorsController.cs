using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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
        public async Task<ActionResult> Index(string q)
        {
            IList<Indicator> indicators = await indicatorsService.GetAllIndicatorsAsync();
            return View(indicators.Where(i => string.IsNullOrEmpty(q) || i.Description.Contains(q)));
        }

        public async Task<ActionResult> IndicatorData(string code)
        {
            IList<WHOStatistics> whoStatistics = await indicatorDataFetcher.GetWHOStatistics(code);
            return View(whoStatistics);
        }


    }
}