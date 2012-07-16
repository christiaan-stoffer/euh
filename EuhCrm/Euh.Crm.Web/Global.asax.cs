using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Euh.Crm.Core.Repository;
using Euh.Crm.Web.Controllers;

namespace Euh.Crm.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Template", // Route name
                "template/save", // URL with parameters
                new {controller = "Template", action = "Save"} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(ControllerFactory.Instance);
        }
    }

    internal class ControllerFactory : DefaultControllerFactory
    {
        private static ControllerFactory _instance;

        private ControllerFactory()
        {
        }

        public static ControllerFactory Instance
        {
            get { return _instance ?? (_instance = new ControllerFactory()); }
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                {
                    throw new ArgumentNullException("controllerType");
                }


                if (!typeof (IController).IsAssignableFrom(controllerType))
                    throw new ArgumentException(string.Format(
                        "Type requested is not a controller: {0}", controllerType.Name),
                                                "controllerType");
                if (controllerType == typeof (TemplateController))
                {
                    return new TemplateController(new MongoTemplateRepository());
                }
                else
                {
                    return base.GetControllerInstance(requestContext, controllerType);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}