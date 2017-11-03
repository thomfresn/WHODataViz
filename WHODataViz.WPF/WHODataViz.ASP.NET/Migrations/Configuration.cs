using WHODataViz.DataModel;

namespace WHODataViz.ASP.NET.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WHODataViz.ASP.NET.Infrastructure.IndicatorsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WHODataViz.ASP.NET.Infrastructure.IndicatorsDb context)
        {
            context.Indicators.AddOrUpdate(i => i.Code,
                new Indicator("CHL", "Cholera"),
                new Indicator("IDS", "Infant death syndrome"));
        }
    }
}
