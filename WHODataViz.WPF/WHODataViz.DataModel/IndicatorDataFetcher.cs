using System.Collections.Generic;
using System.Globalization;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.DataModel
{
    public class IndicatorDataFetcher
    {
        public static IEnumerable<WHOStatistics> GetWHOStatistics(string code)
        {
            //TODO refactor
            string url = $"http://apps.who.int/gho/athena/api/GHO/{code}.json?profile=simple";
            GHOAthenaAPIAccessor athenaApiAccessor = new GHOAthenaAPIAccessor();
            Facts facts = athenaApiAccessor.GetFacts(url);
            foreach (Fact fact in facts.fact)
            {
                if (double.TryParse(fact.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double value))
                {
                    yield return new WHOStatistics(value, fact.dim.YEAR, fact.dim.SEX, fact.dim.COUNTRY, fact.dim.REGION, fact.dim.PUBLISHSTATE == "Published");
                }
            }
        }
    }

    public class WHOStatistics
    {
        public WHOStatistics(double value, string year, string sex, string country, string region, bool isPublished)
        {
            Value = value;
            Year = year;
            Sex = sex;
            Country = country;
            Region = region;
            IsPublished = isPublished;
        }

        public double Value { get; private set; }
        public string Year { get; private set; }
        public string Sex { get; private set; }
        public string Country { get; private set; }
        public string Region { get; private set; }
        public bool IsPublished { get; private set; }
    }
}