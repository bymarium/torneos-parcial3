using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace torneos
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Configuración de rutas de Web API
      config.EnableCors();

      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}