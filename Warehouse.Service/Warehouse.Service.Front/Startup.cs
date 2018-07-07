// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;

using Warehouse.Service.Front;

[assembly: OwinStartup(typeof(Startup))]

namespace Warehouse.Service.Front
{
    using System.Configuration;

    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Hosting;

    using Owin;

    using Warehouse.Common.Logger;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The service url.
        /// </summary>
        private static readonly string ServiceUrl;

        /// <summary>
        /// Initializes static members of the <see cref="Startup"/> class.
        /// </summary>
        static Startup()
        {
            ServiceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
        }

        /// <summary>
        /// The start server.
        /// </summary>
        public static void StartServer()
        {
            using (WebApp.Start<Startup>(ServiceUrl)) 
            {
                Logger.Log("Server running at " + ServiceUrl, LogMessageLevel.Info);
                System.Console.ReadKey();
            }
        }

        /// <summary>
        /// The stop server.
        /// </summary>
        public static void StopServer()
        {
            Logger.Log("Server stopping at " + ServiceUrl, LogMessageLevel.Info);
        }

        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/signalr",
                map =>
                    {
                        // Setup the cors middleware to run before SignalR.
                        // By default this will allow all origins. You can 
                        // configure the set of origins and/or http verbs by
                        // providing a cors options with a different policy.
                        // map.UseCors(CorsOptions.AllowAll);
                        var hubConfiguration = new HubConfiguration
                                                   {
                                                       EnableDetailedErrors = true
                                                   };

                        // Run the SignalR pipeline. We're not using MapSignalR
                        // since this branch is already runs under the "/signalr"
                        // path.
                        map.RunSignalR(hubConfiguration);
                    });
        }
    }
}
