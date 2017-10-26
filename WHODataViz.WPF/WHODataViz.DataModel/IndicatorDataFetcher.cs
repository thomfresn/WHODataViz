using System.Collections.Generic;
using System.Globalization;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.DataModel
{
    public static class IndicatorDataFetcher
    {
        public static IEnumerable<WHOStatistics> GetWHOStatistics(string code)
        {
            GHOAthenaAPIAccessor athenaApiAccessor = new GHOAthenaAPIAccessor();
            Facts facts = athenaApiAccessor.GetFacts(code);
            foreach (Fact fact in facts.fact)
            {
                if (double.TryParse(fact.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double value))
                {
                    yield return new WHOStatistics(value, fact.dim.YEAR, fact.dim.SEX, fact.dim.COUNTRY, fact.dim.REGION, fact.dim.PUBLISHSTATE == "Published");
                }
            }
        }
    }
}