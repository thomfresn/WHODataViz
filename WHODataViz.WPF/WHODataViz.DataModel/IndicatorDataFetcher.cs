using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.DataModel
{
    public class IndicatorDataFetcher : IIndicatorDataFetcher
    {
        public async Task<IndicatorDataItems> GetWHOStatistics(Indicator indicator)
        {
            List<WHOStatistics> statistics = new List<WHOStatistics>();
            GHOAthenaAPIAccessor athenaApiAccessor = new GHOAthenaAPIAccessor();
            Facts facts = await athenaApiAccessor.GetFactsAsync(indicator.Code);
            foreach (Fact fact in facts.fact)
            {
                if (double.TryParse(fact.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double value))
                {
                    statistics.Add(new WHOStatistics(value, fact.dim.YEAR, fact.dim.SEX, fact.dim.COUNTRY, fact.dim.REGION, fact.dim.PUBLISHSTATE == "Published"));
                }
            }
            return new IndicatorDataItems(indicator.Code, indicator.Description, statistics);
        }
    }

    public interface IIndicatorDataFetcher
    {
        Task<IndicatorDataItems> GetWHOStatistics(Indicator indicator);
    }
}