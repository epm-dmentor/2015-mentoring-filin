#region

using System.Web.Http;

#endregion

namespace SDesk
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("Attachements", "api/mails/{id}/attachements/{attId}",
                new {controller = "Attachements", attId = RouteParameter.Optional});

            config.Routes.MapHttpRoute("DefaultApi", "api/mails/{id}",
                new {controller = "Mails", id = RouteParameter.Optional});


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
            config.EnsureInitialized();
        }
    }
}