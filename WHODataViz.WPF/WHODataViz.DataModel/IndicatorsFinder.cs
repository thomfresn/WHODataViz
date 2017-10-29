using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WHODataViz.GHOAccessLib;

namespace WHODataViz.DataModel
{
    public class IndicatorsFinder : IIndicatorsService
    {
        public async Task<IList<Indicator>> GetAllIndicatorsAsync()
        {
            List<Indicator> indicators = new List<Indicator>();
            GHOAthenaAPIAccessor athenaApiAccessor = new GHOAthenaAPIAccessor();
            Codes codes = await athenaApiAccessor.GetCodesAsync();
            Dimension dimension = codes.dimension.SingleOrDefault();
            Debug.Assert(dimension != null, nameof(dimension) + " != null");
            foreach (var code in dimension.code)
            {
                indicators.Add(new Indicator(code.label, code.display));
            }
            return indicators;
        }
    }

    public interface IIndicatorsService
    {
        Task<IList<Indicator>> GetAllIndicatorsAsync();
    }
}