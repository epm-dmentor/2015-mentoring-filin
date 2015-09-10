using System.Web.Http;
using System.Web.Http.Dispatcher;
using Owin;

namespace SelfHostedSDesk
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration webApiConfiguration = ConfigureWebApi();
            app.UseWebApi(webApiConfiguration);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Services.Replace(typeof (IAssembliesResolver), new CustomAssemblyResolver());

            config.Routes.MapHttpRoute(
                "Attachements",
                "api/mails/{id}/attachements/{attId}",
                new {controller = "Attachements", attId = RouteParameter.Optional});

            config.Routes.MapHttpRoute(
                "Mails",
                "api/mails/{id}",
                new {controller = "Mails", id = RouteParameter.Optional});

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional});
            return config;
        }
    }
}