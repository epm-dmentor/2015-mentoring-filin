﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace SelfHostedSDesk
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();
            app.UseWebApi(webApiConfiguration);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute("Attachements", "api/mails/{id}/attachements/{attId}",
                new { controller = "Attachements", attId = RouteParameter.Optional });

            config.Routes.MapHttpRoute("Mails", "api/mails/{id}",
                new { controller = "Mails", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }
    }
}
