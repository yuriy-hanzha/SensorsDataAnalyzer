using SensorsDataAnalyzer.Processing.Classifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SensorsDataAnalyzer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //KNearestNeighborsClassifier.GetInstance().Train();
            //SupportVectorMachineClassifier.GetInstance().Train();
            //NeuralNetworkBasedClassifier.GetInstance().Train();
        }
    }
}
