using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
//using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(WebApiClient.Startup))]

namespace WebApiClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
            ConfigureWebApi(app, config);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            var baseUrl = ConfigurationManager.AppSettings["IdentityServerBaseUrl"];

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = baseUrl,
                ClientId = "salesforce_client",
                RequiredScopes = new[] { "openid", "profile", "postman_api" }
            });

            //app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            //{
            //    ClientId = "expedo_client",
            //    AuthenticationType = "code",
            //    Authority = baseUrl,
            //    Scope = "postman_api",
            //    RedirectUri = "http://localhost:61744",
            //    RequireHttpsMetadata = false
            //});

        }

        private static void ConfigureWebApi(IAppBuilder app, HttpConfiguration config)
        {
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }

   
}
