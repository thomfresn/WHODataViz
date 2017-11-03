
using System.Data.Entity;
using System.Linq;
using WHODataViz.DataModel;

namespace WHODataViz.ASP.NET.Infrastructure
{
    public class IndicatorsDb : DbContext, IIndicatorsDataSource
    {
        public IndicatorsDb() : base("DefaultConnection")
        {
            
        }

        public DbSet<Indicator> Indicators { get; set; }

        IQueryable<Indicator> IIndicatorsDataSource.Indicators => Indicators;
    }



    public interface IIndicatorsDataSource
    {
        IQueryable<Indicator> Indicators { get; }
    }
}