using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.DataModel
{
    public static class IndicatorsFinder
    {
        public static IEnumerable<Indicator> GetAllIndicators()
        {
            GHOAthenaAPIAccessor athenaApiAccessor = new GHOAthenaAPIAccessor();
            Codes codes = athenaApiAccessor.GetCodes();
            Dimension dimension = codes.dimension.SingleOrDefault();
            Debug.Assert(dimension != null, nameof(dimension) + " != null");
            foreach (var code in dimension.code)
            {
                yield return new Indicator(code.label, code.display);
            }
        }
    }
}