using BLD2H.Implementations;
using BLD2H.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using WebApiD2h.Models;

namespace WebApiD2h
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            
            container.RegisterType<IPackageBL, PackageBL>();
            container.RegisterType<ICustomerBL, CustomerBL>();
            container.RegisterType<IGroupBL, GroupBL>();
            container.RegisterType<ICityBL, CityBL>();
            container.RegisterType<IStatusBL, StatusBL>();


            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
