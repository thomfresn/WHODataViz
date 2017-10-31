using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WHODataViz.DataModel;

namespace WHODataViz.ASP.NET.Controllers
{
    public class IndicatorsController : Controller
    {
        // GET: Indicators
        public async Task<ActionResult> Index()
        {
            IndicatorsFinder indicatorsFinder = new IndicatorsFinder();
            IList<Indicator> indicators = await indicatorsFinder.GetAllIndicatorsAsync();
            return View(indicators);
        }

        public async Task<ActionResult> IndicatorData(string code)
        {
            IList<WHOStatistics> whoStatistics = await IndicatorDataFetcher.GetWHOStatistics(code);
            return View(whoStatistics);
        }


    }
}