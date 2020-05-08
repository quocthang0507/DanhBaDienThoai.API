using DanhBaDienThoai.API.Models;
using System.Web.Http;

namespace DanhBaDienThoai.API
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Basic authentication for websites
			config.Filters.Add(new BasicAuthenticationAttribute());

			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "DefaultApi2",
				routeTemplate: "api/{controller}/{action}/{name}",
				defaults: new { name = RouteParameter.Optional }
			);
		}
	}
}
