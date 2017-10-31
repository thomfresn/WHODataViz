

using System;
using System.Web.Mvc;
using System.Web.Routing;
using WHODataViz.DataModel;

namespace WHODataViz.ASP.NET.Infrastructure
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return Activator.CreateInstance(controllerType, new IndicatorsFinder(), new IndicatorDataFetcher()) as IController;
        }
    }
}